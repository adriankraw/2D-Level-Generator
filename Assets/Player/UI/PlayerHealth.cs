using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image HealthBackGround;
    [SerializeField] Image HealthBar;

    private Vector3 localScale = Vector3.one;
    private void Awake()
    {
        HealthBar.transform.localScale = localScale;
    }

    public void SetHealthBar(float Value)
    {
        localScale.x = Value;
        HealthBar.transform.localScale = localScale;
    }
}
