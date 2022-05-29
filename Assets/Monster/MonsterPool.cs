using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public GameObject[] monsters;
    private int spawned;
    public bool spawnable = true;

    private void Awake() {
        foreach(GameObject monster in monsters){
            monster.SetActive(false);
        }
    }
    public bool CheckSpawn(){
        // if(spawned + 1 < monsters.Length)
        // {
        //     spawned++;
            return true;
        // }else{
        //     return false;
        // }
    }
}
