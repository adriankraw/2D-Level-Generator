using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class characterController : MonoBehaviour
{
    private MainChar mainInput;
    private Camera mainCam;

    [Header("Stats-Values")]
    public bool isTouchingGround;
    public bool isTouchingHead;
    public bool isTouchingSide;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] BoxCollider2D _collider2D;
    [SerializeField] inventar inventar;
    [SerializeField] inventarScreen invScreen;
    [SerializeField] PlayerBullets playerBullets;
    [SerializeField] float walkSpeed = 1;
    [SerializeField] float fric = 5;
    [SerializeField] float jumpStrg = 20F;
    [SerializeField] float maxspeed;
    [SerializeField] float gravity = 0.6F;
    [SerializeField] LayerMask layermask;

    [SerializeField] Transform TileSelection;

    [SerializeField] TileBases[] tiles;

    [SerializeField] LineRenderer lineRenderer;

    public ContactFilter2D contactFilter2D;

    private RaycastHit2D hit;
    Vector2 move = Vector2.zero;
    float space = 0f;
    private MovementColliders movementColliders;
    private Vector3 bulletPosition;
    private Vector3 bulletangle;
    private bool mouseWasPressed;

    private bool weaponselected = false;
    Coroutine weaponAttack;

    private void Awake()
    {
        mainInput = new MainChar();
        mainCam = Camera.main;
        inventar.InitInventar(10, invScreen);
        movementColliders = new MovementColliders();
        lineRenderer.enabled = false;
    }
    private void OnEnable()
    {
        mainInput.Enable();
    }
    private void OnDisable()
    {
        mainInput.Disable();
    }

    void Update()
    {
        Vector3 mousePosi = Camera.main.ScreenToWorldPoint(mainInput.Game.MousePosition.ReadValue<Vector2>());
        LeftMouseButton(mousePosi);

        #region Buttons

        InventoryButtons();
        #endregion

        CameraController();

        move.x += mainInput.Game.Move.ReadValue<Vector2>().x;
        if (mainInput.Game.Move.ReadValue<Vector2>().y < 0)
        {
            move.y += mainInput.Game.Move.ReadValue<Vector2>().y * 0.05F;
        }
        space = mainInput.Game.Jump.ReadValue<float>();

        #region Colliders
        isTouchingSide = movementColliders.CheckSides(move, transform, layermask);
        isTouchingHead = movementColliders.HeadCheck(transform, layermask);
        isTouchingGround = movementColliders.GroundCheck(transform, layermask);

        if (isTouchingSide)
        {
            move.x = 0;
        }
        if (isTouchingGround)
        {
            if (isTouchingHead)
            {
                move.y = 0;
            }
            else
            {
                move.y = space * jumpStrg;
            }
        }
        else 
        {
            if (isTouchingHead)
            {
                move.y = -1 - gravity * Time.deltaTime;
            }
            else
            {
                move.y -= gravity * Time.deltaTime;
            }
        }
        #endregion



        if (move.x > 0)
        {
            if (move.x - (0.1F * fric) < 0)
            {
                move.x = 0;
            }
            else
            {
                move.x -= (0.1F * fric);
            }
        }
        else
        {
            if (move.x + (0.1F * fric) > 0)
            {
                move.x = 0;
            }
            else
            {
                move.x += (0.1F * fric);
            }
        }
        if (move.x > maxspeed)
        {
            move.x = maxspeed;
        }
        else if (move.x < -maxspeed)
        {
            move.x = -maxspeed;
        }
        transform.Translate(move * walkSpeed * Time.deltaTime);
    }

    private void LeftMouseButton(Vector3 mousePosi)
    {
        if(inventar.items[inventar.GetSelectedItem()] == null)return; 

        switch(inventar.items[inventar.GetSelectedItem()].itemEnums)
        {
            case ItemEnums.Weapon:
                if (mainInput.Game.MouseClick.IsPressed())
                {
                    if (mouseWasPressed == false)
                    {
                        mouseWasPressed = true;
                        if (weaponAttack == null)
                        {
                            weaponAttack = StartCoroutine(CheckMouseClick());
                        }
                    }
                }
                else
                {
                    weaponAttack = null;
                    if (mouseWasPressed == true)
                    {
                        mouseWasPressed = false;
                    }
                }
            break;
            case ItemEnums.Pickaxe:
                if (Vector3.Distance(this.transform.position, mousePosi) < 4)
                {
                    if (!lineRenderer.enabled) { lineRenderer.enabled = true; }

                    Vector3Int Cell = Map.instance.tilemap.layoutGrid.WorldToCell(mousePosi);
                    Vector3 _cell = Map.instance.tilemap.GetCellCenterWorld(Cell);

                    lineRenderer.SetPosition(0, new Vector3(_cell.x - 0.5F, _cell.y + 0.5F, 0));
                    lineRenderer.SetPosition(1, new Vector3(_cell.x + 0.5F, _cell.y + 0.5F, 0));
                    lineRenderer.SetPosition(2, new Vector3(_cell.x + 0.5F, _cell.y - 0.5F, 0));
                    lineRenderer.SetPosition(3, new Vector3(_cell.x - 0.5F, _cell.y - 0.5F, 0));
                    lineRenderer.SetPosition(4, new Vector3(_cell.x - 0.5F, _cell.y + 0.5F, 0));
                    lineRenderer.SetPosition(5, new Vector3(_cell.x + 0.5F, _cell.y + 0.5F, 0));
                }else{
                    if (lineRenderer.enabled) { lineRenderer.enabled = false; }
                }
                if (mainInput.Game.Interact.IsPressed() || (mainInput.Game.MouseClick.IsPressed()))
                {
                    if (Vector3.Distance(this.transform.position, mousePosi) < 4)
                    {
                        Vector3Int selectedTilePosition = Map.instance.tilemap.WorldToCell(mousePosi);
                        TileBase b = Map.instance.tilemap.GetTile(selectedTilePosition);
                        for (int i = 0; i < tiles.Length; i++)
                        {
                            if (tiles[i].tilebase != null && tiles[i].tilebase == b)
                            {
                                inventar.AddItem(tiles[i]);
                            }
                        }
                        Map.instance.tilemap.SetTile(selectedTilePosition, null);
                    }
                }
            break;
            case ItemEnums.Tile:
                if (Vector3.Distance(this.transform.position, mousePosi) < 4)
                {
                    if (!lineRenderer.enabled) { lineRenderer.enabled = true; }

                    Vector3Int Cell = Map.instance.tilemap.layoutGrid.WorldToCell(mousePosi);
                    Vector3 _cell = Map.instance.tilemap.GetCellCenterWorld(Cell);

                    lineRenderer.SetPosition(0, new Vector3(_cell.x - 0.5F, _cell.y + 0.5F, 0));
                    lineRenderer.SetPosition(1, new Vector3(_cell.x + 0.5F, _cell.y + 0.5F, 0));
                    lineRenderer.SetPosition(2, new Vector3(_cell.x + 0.5F, _cell.y - 0.5F, 0));
                    lineRenderer.SetPosition(3, new Vector3(_cell.x - 0.5F, _cell.y - 0.5F, 0));
                    lineRenderer.SetPosition(4, new Vector3(_cell.x - 0.5F, _cell.y + 0.5F, 0));
                    lineRenderer.SetPosition(5, new Vector3(_cell.x + 0.5F, _cell.y + 0.5F, 0));
                }else{
                    if (lineRenderer.enabled) { lineRenderer.enabled = false; }
                }
                if (mainInput.Game.Interact.IsPressed() || (mainInput.Game.MouseClick.IsPressed()))
                {
                    if (Vector3.Distance(this.transform.position, mousePosi) < 4)
                    {
                        Vector3Int selectedTilePosition = Map.instance.tilemap.WorldToCell(mousePosi);
                        TileBase b = Map.instance.tilemap.GetTile(selectedTilePosition);
                        for (int i = 0; i < tiles.Length; i++)
                        {
                            if (tiles[i].tilebase != null && tiles[i].tilebase == b)
                            {
                                inventar.AddItem(tiles[i]);
                            }
                        }
                        Map.instance.tilemap.SetTile(selectedTilePosition, inventar.items[inventar.GetSelectedItem()].tileBases.tilebase);
                    }
                }
            break;
            default:
                break;
        }
        if((inventar.items[inventar.GetSelectedItem()].itemEnums != ItemEnums.Pickaxe) &&
            (inventar.items[inventar.GetSelectedItem()].itemEnums != ItemEnums.Tile))
        {
            if (lineRenderer.enabled) { lineRenderer.enabled = false; }
        }
    }

    IEnumerator CheckMouseClick()
    {
        while (mainInput.Game.MouseClick.IsPressed())
        {
            bulletangle.x = Camera.main.ScreenToWorldPoint(mainInput.Game.MousePosition.ReadValue<Vector2>(), Camera.MonoOrStereoscopicEye.Mono).x - this.transform.position.x;
            bulletangle.y = Camera.main.ScreenToWorldPoint(mainInput.Game.MousePosition.ReadValue<Vector2>(), Camera.MonoOrStereoscopicEye.Mono).y - this.transform.position.y;

            bulletPosition.x = this.transform.position.x + bulletangle.normalized.x;
            bulletPosition.y = this.transform.position.y + bulletangle.normalized.y;
            bulletPosition.z = 0;

            playerBullets.ShootBullet(bulletPosition, bulletangle.normalized * 10);
            yield return new WaitForSecondsRealtime(0.5F);
        }
    }

    private void CameraController()
    {
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 CurrentResolition = new Vector3(Screen.width, Screen.height, 0);
        float cameraSpeed = 1F;

        if ((playerPosition.x < CurrentResolition.x *2/5 || playerPosition.x > CurrentResolition.x *3/5)
            || (playerPosition.y < CurrentResolition.y *2/5 || playerPosition.y > CurrentResolition.y *3/5))
        {
            mainCam.transform.position = Camera.main.ScreenToWorldPoint(new Vector2( Earp(CurrentResolition.x/2, playerPosition.x, cameraSpeed * Time.deltaTime), Earp(CurrentResolition.y / 2, playerPosition.y, cameraSpeed * Time.deltaTime)));
        }

    }

    public float Earp(float a, float b, float t)
    {
        a = a * (Mathf.Pow((b / a),t));
        return a;
    }


    private void InventoryButtons()
    {
        if (mainInput.Screen.Screen_Inv_1.IsPressed())
        {
            inventar.SetSelectedItem(0);
        }
        if (mainInput.Screen.Screen_Inv_2.IsPressed())
        {
            inventar.SetSelectedItem(1);
        }
        if (mainInput.Screen.Screen_Inv_3.IsPressed())
        {
            inventar.SetSelectedItem(2);
        }
        if (mainInput.Screen.Screen_Inv_4.IsPressed())
        {
            inventar.SetSelectedItem(3);
        }
        if (mainInput.Screen.Screen_Inv_5.IsPressed())
        {
            inventar.SetSelectedItem(4);
        }
        if (mainInput.Screen.Screen_Inv_6.IsPressed())
        {
            inventar.SetSelectedItem(5);
        }
        if (mainInput.Screen.Screen_Inv_7.IsPressed())
        {
            inventar.SetSelectedItem(6);
        }
        if (mainInput.Screen.Screen_Inv_8.IsPressed())
        {
            inventar.SetSelectedItem(7);
        }
        if (mainInput.Screen.Screen_Inv_9.IsPressed())
        {
            inventar.SetSelectedItem(8);
        }
        if (mainInput.Screen.Screen_Inv_0.IsPressed())
        {
            inventar.SetSelectedItem(9);
        }
    }
}
