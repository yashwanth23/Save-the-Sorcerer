using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandMovement : MonoBehaviour {

/******************************************************************************************************************************
This script is for pointing the wand towards the mouse position at all times
******************************************************************************************************************************/

    public GameObject wand;
	
	// Update is called once per frame
	void Update () {
        wand.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }
}
