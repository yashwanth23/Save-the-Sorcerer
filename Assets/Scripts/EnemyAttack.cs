using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************************************************************************************************
 This script is for identifying the distance of the enemy from the player and playing attacking animation while the enemy reaches closer to the Player
 ********************************************************************************************************************************************************/

public class EnemyAttack : MonoBehaviour {

    private GameObject target;
    private float reachDistance;

    // Use this for initialization
    void Start () {
        //Find Player gameobject and assign as Target
        target = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {

        //Calculate the distance of the player from this gameobkect (enemy)
        reachDistance = Vector3.Distance(transform.position, target.transform.position);
        //Debug.Log(reachDistance);

        //If the enemy reaches closer to the player change animation to attacking animation
        if (reachDistance < 3.0f)
        {
            GetComponent<Animation>().Play("attack_short_001");
            
        }
    }
}
