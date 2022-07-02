using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{
    public static playerData instance;
    [SerializeField] PlayerHealth playerHealth;

    private float Health = 100;
    private float maxHealth = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public Vector3 GetPositionData()
    {
        return transform.position;
    }
    public void TakeDamage(float f)
    {
        Health -= f;
        if (Health < 0) Health = 0;
        if(Health > maxHealth) Health = maxHealth;
        playerHealth.SetHealthBar(Health / maxHealth);
    }
}
