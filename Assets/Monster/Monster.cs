using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Health = 100;
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

    private float maxHealth;

    [SerializeField] PlayerHealth playerHealth;


    private void Awake()
    {
        movementColliders = new MovementColliders();
        stateMachine = new MonsterStateMachine();
        stateMachine.SetMonster(this);
        maxHealth = Health;
        stateMachine.ChangeState(MonsterState.wating);
    }
    public void TakeDamage(int Value)
    {
        Health -= Value;
        if (Health < 0) { Health = 0; }
        if (Health > maxHealth) { Health = maxHealth; }
        playerHealth.SetHealthBar(Health/maxHealth);
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
