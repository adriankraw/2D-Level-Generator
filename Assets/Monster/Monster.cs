using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int Health = 100;
    [SerializeField] float gravity = 9.81F;
    [SerializeField] float walkSpeed = 2;
    [SerializeField] LayerMask moveLayerMask;
    Vector3 move = new Vector3();
    private RaycastHit2D hit;
    [SerializeField] bool isGround = false;
    [SerializeField] float fric = 5;

    [Header("Rules")]
    [SerializeField] float distanceToPlayer = 1.1F;

    private MovementColliders movementColliders;

    private void Awake()
    {
        movementColliders = new MovementColliders();
    }

    private void Update()
    {
        isGround = movementColliders.GroundCheck(transform,moveLayerMask);
        if (!isGround)
        {
            move.y -= gravity * Time.deltaTime;
        }
        else
        {
            move.y = 0;
        }


        float distance = this.transform.position.x - playerData.instance.GetPositionData().x;
        if (Mathf.Abs(distance) > distanceToPlayer)
        {
            move.x = Mathf.Clamp(playerData.instance.GetPositionData().x - this.transform.position.x, -1F, 1F);
            if (movementColliders.CheckSides(move, transform,moveLayerMask))
            {
                move.x = 0;
                if (isGround)
                {
                    move.y = 6F;
                }
            }
        }
        else
        {
            move.x = 0;
        }

        move.z = 0;
        transform.Translate(move * walkSpeed * Time.deltaTime);
    }
}
