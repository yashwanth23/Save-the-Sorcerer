using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***********************************************************************************************************************************************
 This script is to move the enemy towards the player and also orient the enemy in a way that it always faces the player
 ***********************************************************************************************************************************************/

public class EnemyMove : MonoBehaviour {

    private GameObject target;
    private float speed;

    // Use this for initialization
    void Start()
    {
        speed = 1.0f;

        //Find player gameobject and assign as target
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Get the direction of target from this gameobject(enemy) 
        Vector3 targetDir = target.transform.position - transform.position;

        //Value of each step
        float step = speed * Time.deltaTime;

        //Turn towards the target 
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        //Move towards the target and orient the enemy in a way that it faces the target 
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
