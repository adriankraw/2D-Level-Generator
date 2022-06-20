using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int Health = 100;
    public float gravity = 9.81F;
    public float walkSpeed = 2;
    public LayerMask moveLayerMask;
    public bool isGround = false;
    public float fric = 5;

    [Header("Rules")]
    public float distanceToPlayer = 1.1F;

    MonsterStateMachine stateMachine;
    public float currentdistance;
    public MovementColliders movementColliders;

    private void Awake()
    {
        movementColliders = new MovementColliders();
        stateMachine = new MonsterStateMachine();
        stateMachine.SetMonster(this);
        stateMachine.ChangeState(MonsterState.wating);
    }

    private void Update()
    {
        currentdistance = this.transform.position.x - playerData.instance.GetPositionData().x;
        if (currentdistance < 0) currentdistance *= -1;

        if (currentdistance < 1F)
        {
            stateMachine.ChangeState(MonsterState.attacking);
        }
        else
        if (currentdistance < 10F)
        {
            stateMachine.ChangeState(MonsterState.following);
        }
        else
        if (currentdistance < 25F)
        {
            stateMachine.ChangeState(MonsterState.searching);
        }
        else {
            stateMachine.ChangeState(MonsterState.wating);
        }
        stateMachine.UpdateState();
    }
}
