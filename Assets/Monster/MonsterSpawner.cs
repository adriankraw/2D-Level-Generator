using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] float startTime = 0;
    [SerializeField] float roundsLength = 5;
    [SerializeField] MonsterPool monsterPool;

    bool spawining = true;
    WaitForSecondsRealtime RoundsLengthWaiting;

    void Start()
    {
        RoundsLengthWaiting = new WaitForSecondsRealtime(roundsLength);
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSecondsRealtime(startTime);

        while(true)
        {
            if(monsterPool.CheckSpawn() && spawining)
            {
                //spawn
            }
            yield return RoundsLengthWaiting;
        }
    }
}
