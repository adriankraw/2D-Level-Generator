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
            //other ist das Monster;
            other.GetComponent<Monster>().TakeDamage(10, move);
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
    public void reset()
    {
        move = Vector3.zero;
        this.transform.position = playerData.instance.GetPositionData();
        aliveForSeconds = 0;
        this.GetComponent<TrailRenderer>().Clear();
        this.GetComponent<TrailRenderer>().enabled = false;
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        this.transform.position = Vector3.zero;
        this.GetComponent<TrailRenderer>().enabled = false;

    }
    private void OnEnable()
    {
        this.GetComponent<TrailRenderer>().enabled = true;
    }
}
