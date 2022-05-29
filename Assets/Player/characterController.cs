using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class characterController : MonoBehaviour
{
    private MainChar mainInput;
    private Camera mainCam;

    [Header("Stats-Values")]
    public bool isGround;
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

    public ContactFilter2D contactFilter2D;

    private RaycastHit2D hit;
    Vector2 move = Vector2.zero;
    float space = 0f;
    private MovementColliders movementColliders;
    private Vector3 bulletPosition;
    private Vector3 bulletangle;
    private bool mouseWasPressed;

    private void Awake()
    {
        mainInput = new MainChar();
        mainCam = Camera.main;
        inventar.InitInventar(10, invScreen);
        movementColliders = new MovementColliders();
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
        #region Buttons
        if (mainInput.Game.Interact.IsPressed())
        {
            Vector3Int selectedTilePosition = Map.instance.tilemap.WorldToCell(TileSelection.position);
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
        if (mainInput.Game.MouseClick.IsPressed())
        {
            if(mouseWasPressed == false)
            {
                mouseWasPressed = true;
                StartCoroutine(CheckMouseClick());
            }
        }else{
            if(mouseWasPressed == true)
            {
                mouseWasPressed = false;
            }
        }
        #endregion

        CameraController();

        move.x += mainInput.Game.Move.ReadValue<Vector2>().x;
        if (mainInput.Game.Move.ReadValue<Vector2>().y < 0)
        {
            move.y += mainInput.Game.Move.ReadValue<Vector2>().y * 0.05F;
        }
        space = mainInput.Game.Jump.ReadValue<float>();

        #region Colliders
        if (movementColliders.CheckSides(move, transform,layermask))
        {
            move.x = 0;
        }

        isGround = movementColliders.GroundCheck(transform,layermask);
        if (isGround)
        {
            move.y = space * jumpStrg;
        }
        else
        {
            if (movementColliders.HeadCheck(transform,layermask))
            {
                move.y = 0 - gravity * Time.deltaTime;
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
    IEnumerator CheckMouseClick()
    {
        while (mainInput.Game.MouseClick.IsPressed())
        {
            bulletangle.x = Camera.main.ScreenToWorldPoint(mainInput.Game.MousePosition.ReadValue<Vector2>(), Camera.MonoOrStereoscopicEye.Mono).x - this.transform.position.x;
            bulletangle.y = Camera.main.ScreenToWorldPoint(mainInput.Game.MousePosition.ReadValue<Vector2>(), Camera.MonoOrStereoscopicEye.Mono).y  - this.transform.position.y;
            
            bulletPosition.x = this.transform.position.x + bulletangle.normalized.x;
            bulletPosition.y = this.transform.position.y + bulletangle.normalized.y;
            bulletPosition.z = 0;

            playerBullets.ShootBullet(bulletPosition, bulletangle.normalized * 10);
            yield return new WaitForSecondsRealtime(0.5F);
        }
    }

    private void CameraController()
    {
        mainCam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
    }
}
