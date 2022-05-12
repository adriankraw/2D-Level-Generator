using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    private MainChar mainInput;
    private Camera mainCam;

    [Header("Stats-Values")]
    public bool isGround;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] BoxCollider2D _collider2D;
    [SerializeField] float walkSpeed = 1;
    [SerializeField] float fric = 5;
    [SerializeField] float jumpStrg = 20F;
    [SerializeField] float maxspeed;
    [SerializeField] float gravity = 0.6F;

    public ContactFilter2D contactFilter2D;

    private RaycastHit2D hit;
    Vector2 move = Vector2.zero;

    private void Awake() {
        mainInput = new MainChar();
        mainCam = Camera.main;
    }
    private void OnEnable() {
        mainInput.Enable();
    }
    private void OnDisable() {
        mainInput.Disable();
    }

    void Update()
    {
        mainCam.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,0);

        move.x += mainInput.Game.Move.ReadValue<Vector2>().x;
        if(mainInput.Game.Move.ReadValue<Vector2>().y < 0)
        {
            move.y += mainInput.Game.Move.ReadValue<Vector2>().y * 0.05F;
        }
        float space = mainInput.Game.Jump.ReadValue<float>();

        hit = Physics2D.BoxCast(transform.position,Vector2.one * 0.8F,0,transform.TransformDirection(Vector3.down),0.1F);
        if(hit)
        {
            isGround = true;
        }else{
            isGround = false;
        }
        hit = Physics2D.BoxCast(transform.position,Vector2.one * 0.4F,0,transform.TransformDirection(Vector3.left),0.5F);
        if(hit){
            if(move.x < 0) move.x = 0;
        }
        hit = Physics2D.BoxCast(transform.position,Vector2.one * 0.4F,0,transform.TransformDirection(Vector3.right),0.5F);
        if(hit){
            if(move.x > 0) move.x = 0;
        }
        if(isGround)
        {
            move.y = space * jumpStrg;
        }else{
            // if(move.y > -3F)
            move.y -= gravity * Time.deltaTime;
        }
        if(move.x > 0)
        {
            if(move.x -(0.1F * fric) < 0)
            {
                move.x = 0;
            }else{
                move.x -= (0.1F * fric);
            }
        }else{
            if(move.x + (0.1F * fric) > 0)
            {
                move.x = 0;
            }else{
                move.x += (0.1F * fric);
            }
        }
        if(move.x > maxspeed)
        {
            move.x = maxspeed;
        }else if(move.x < -maxspeed){
            move.x = -maxspeed;
        }
    }
    private void FixedUpdate() {
        transform.Translate(move * walkSpeed * Time.fixedDeltaTime);
    }
}