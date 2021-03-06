using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Health = 100F;
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

    public float maxHealth = 100F;

    private float attackSpeed = 0;
    public bool IsAttacking = true;
    public AnimationCurve deathAnimation;
    private Vector3 scale;

    [SerializeField] PlayerHealth playerHealth;


    private void Awake()
    {
        movementColliders = new MovementColliders();
        stateMachine = new MonsterStateMachine();
        Health = 100F;
        maxHealth = 100F;
        this.scale = this.transform.localScale;
        stateMachine.SetMonster(this);
        stateMachine.ChangeState(MonsterState.waiting);
    }
    public void TakeDamage(int Value, Vector3 move)
    {
        this.Health = this.Health - Value;
        if (this.Health < 0) 
        {
            StartCoroutine(deathAnimationCo());
        }
        if (this.Health > this.maxHealth) 
        { 
            this.Health = this.maxHealth; 
        }
        playerHealth.SetHealthBar(Health/maxHealth);
        this.transform.position = this.transform.position + move / 20;
    }
    IEnumerator deathAnimationCo()
    {
        float timing = 0.2F;
        Vector3 scale = this.transform.localScale;
        while (timing > 0)
        {
            timing -= Time.deltaTime;
            this.transform.localScale = scale * deathAnimation.Evaluate(timing);
            yield return null;
        }
        this.gameObject.SetActive(false);
        yield return null;
        this.transform.localScale = scale;
    }
    private void Update()
    {
        currentdistance = this.transform.position.x - playerData.instance.GetPositionData().x;
        if (currentdistance < 0) currentdistance *= -1;

        if (currentdistance < 1F)
        {
            CheckForIsAttacking();
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
        else
        {
            stateMachine.ChangeState(MonsterState.waiting);
        }
        stateMachine.UpdateState();
    }

    private void CheckForIsAttacking()
    {
        if (attackSpeed > 1)
        {
            IsAttacking = true;
            attackSpeed = 0;
        }
        else
        {
            IsAttacking = false;
            attackSpeed += Time.deltaTime;
        }
    }

    public void Reset()
    {
        Health = maxHealth;
        this.transform.localScale = this.scale;
        playerHealth.SetHealthBar(Health / maxHealth);
    }
    public float GetDamage()
    {
        return 10F;
    }
}
