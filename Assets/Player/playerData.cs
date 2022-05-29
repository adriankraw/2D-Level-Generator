using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{
    public static playerData instance;

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
}
