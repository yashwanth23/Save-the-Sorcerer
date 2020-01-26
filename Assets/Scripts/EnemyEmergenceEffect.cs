using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*************************************************************************************************************************************
 This script is for spawning the enemies at periodic intervals at random locations while also showing summoning effect while spawning
 *************************************************************************************************************************************/

public class EnemyEmergenceEffect : MonoBehaviour {

    [SerializeField]
    public GameObject summonEffect;
    public GameObject enemySummon;
    GameObject clone;
    GameObject cloneEnemy;

    float x, y, z;
    private int count;
    Vector3 pos;
    
	void Update () {

        //Spawning enemies at regular intervals at a random location
        count++;
        if (count%250 == 0)
        {
            x = UnityEngine.Random.Range(-20, 20);
            y = UnityEngine.Random.Range(1, 2); 
            z = UnityEngine.Random.Range(-30, 10);
            pos = new Vector3(x, y, z);
            transform.position = pos;
            
            summonEffect.SetActive(true);

            //create an enemy summon effect
            //Clone the summon effect and instantiate the enemy at the random location defined earlier  
            clone = Instantiate(summonEffect, transform.position, transform.rotation);
            cloneEnemy = Instantiate(enemySummon, transform.position, transform.rotation);
            
        }

        //Destroy the summon effect when enemy is instantiated
        GameObject.Destroy(clone, 3f);
            
    }

}
    