using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventarScreen : MonoBehaviour
{
    public List<Image> Images = new List<Image>();
    public int lastImageIndex;
    public void ReadImages()
    {
        foreach (Transform trans in GetComponentInChildren<Transform>())
        {
            Images.Add(trans.GetComponent<Image>());
            Images[Images.Count - 1].color = new Color(1, 1, 1, 0.5F);
        }
    }
    public void DeSelect(int item)
    {
        Images[item].color = new Color(1,1,1,0.5F);
    }
    public void Select(int item)
    {
        Images[item].color = new Color(1,1,1,1F);
    }
}
