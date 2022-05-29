using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventarScreen : MonoBehaviour
{
    public List<Image> Images = new List<Image>();
    public void ReadImages(){
        foreach(Transform trans in GetComponentInChildren<Transform>())
        {
            Images.Add(trans.GetComponent<Image>());
        }
    }
}
