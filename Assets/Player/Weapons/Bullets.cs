using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [HideInInspector]
    public Vector3 move = Vector3.zero;

    public float aliveForSeconds = 0;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Monster")
        {
            this.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
        if(other.tag == "Terrain")
        {
            this.gameObject.SetActive(false);
        }
    }
    private void FixedUpdate() {

        if(aliveForSeconds > 5)
        {
            reset();
        }
        if(move.magnitude != 0)
        {
            transform.Translate(move * Time.fixedDeltaTime);
            aliveForSeconds+= Time.fixedDeltaTime;
        }
    }
    public void reset() {
        move = Vector3.zero;
        aliveForSeconds = 0;
        this.gameObject.SetActive(false);
    }
}
