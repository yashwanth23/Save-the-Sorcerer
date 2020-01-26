using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************************************************************************************
This script is to cast a spell on the enemy and execute the respective effect on it. There are 3 spells that are coded in the game, they are "Expeliamus", 
"Ridiculous" and, "Vingadiyum Leviyosa". Each spell has their own visual effects and sound effects on the enemy. Once the spell is executed, any residual 
gameobjects are destroyed to optimize the performance.
********************************************************************************************************************************************************/
 
public class HitEnemy : MonoBehaviour {

    private GameObject[] spellitem;
    
    //Defining booleans for various effects related to spells
    private bool isDestroyed = false;
    private bool isModified = false;
    private bool isthrown = false;
    //private int count = 0;
    //public int score;

    public GameObject toy;

    private Vector3 force;
    private int hoverForce;
    private float spellDuration;

    //public GameObject DestroyEffect;


	void Start () {
        spellitem = new GameObject[3];

        //Assigning spell particle system prefabs as gameobjects
        spellitem[0] = GameObject.FindGameObjectWithTag("spell");
        spellitem[1] = GameObject.FindGameObjectWithTag("spell2");
        spellitem[2] = GameObject.FindGameObjectWithTag("spell3");
    }
	
	void Update () {
        //Debug.Log("Works");

        //This is for first spell which is "Expeliamus" 
        //If the spell is launched, destroy the enemy and the spell gameobject
        if (isDestroyed == true)
        {
            GameObject.Destroy(spellitem[0]);
            Object.Destroy(this.gameObject);
            isDestroyed = false; //Make it default to avoid null reference

            //score++;
            //Debug.Log("Score: " + score);
        }

        //This is for the second spell which is "Ridiculous"
        //If the spell is launched, destroy the enemy, spell gameobject and instantiate the toy gamobject 
        if (isModified == true)
        {
            GameObject.Destroy(spellitem[1]);
            Object.Destroy(this.gameObject);
            Instantiate(toy, transform.position, transform.rotation);
            isModified = false; //Make it default to avoid null reference

            //score++;
            //Debug.Log("Score: " + score);
        }

        //This is for the thrid spell which is "Vigadiyum Leviyosa"
        //If the spell is launched destroy the spell gameobject and add a force upwards on the enemy to repel it away
        if (isthrown == true)
        {
            GameObject.Destroy(spellitem[2]);

            //Adding an upward force and freezing the remaining axis 
            GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            isthrown = false; //Make it default to avoid null reference

            //score++;
            //Debug.Log("Score: " + score);
        }
        
    }

    //This is executed when the magic spell that is released by the player touches the enemy
    void OnTriggerEnter(Collider magic)
    {
        
        //If the spell casted by the player is "Expeliamus" and if it hits the enemy 
        if (magic.gameObject.tag == "spell")
        {
            //count++;
            Debug.Log("Enemy was destroyed");
            //Play getting destroyed animation
            GetComponent<Animation>().Play("damage_001");

            //Use coroutine to give buffer time for destruction of the enemy
            StartCoroutine(DestroyTimer());
            
        }
        //If the spell casted by the player is "Ridiculous" and if it hits the enemy 
        else if (magic.gameObject.tag == "spell2")
        {
            //count++;
            Debug.Log("Enemy was swaped");
            //Make the condition true in order to execute the respective effect of the cast spell
            isModified = true;

        }
        //If the spell casted by the player is "Vingadiyum Leviyosa" and if it hits the enemy 
        else if (magic.gameObject.tag == "spell3")
        {
            hoverForce = 100;
            
            Debug.Log("Enemy was repeled away");
            //Make the condition true in order to execute the respective effect of the cast spell
            isthrown = true;

        }

    }

    IEnumerator DestroyTimer()
    {
        //Wait time of half the animation time of enemy being destroyed is given 
        yield return new WaitForSeconds(GetComponent<Animation>()["damage_001"].length/2);

        //Make the condition true in order to execute the respective effect of the cast spell
        isDestroyed = true;
    }
  
}


