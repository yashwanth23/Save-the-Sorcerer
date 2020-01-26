using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************************************************************************************************************
 This script is for launching different magic spells with respective particle effects and sound effects from the wand that is attached to the player
 **************************************************************************************************************************************************/
public class BulletLaunch : MonoBehaviour {

    public ParticleSystem[] spell;    
    ParticleSystem spellclone;

    public Transform spellLauncher;
    
    private float speed = 2000;

    public AudioClip[] spellSound; 

    private AudioSource source;

    public static int spellcast;
    private int changeSpell = 0; 


	void Start () {
        source = GetComponent<AudioSource>();
        
    }
	
	void Update () {
        //Get the spell number from spellChange script in order to execute the respective effect 
        spellcast = ChangeSpell.spellChange;

        //When spell is cast and mouse button clicked
        if (Input.GetMouseButtonDown(0))
        {
            //Identify the spell number and execute the effect accordingly 
            switch (spellcast)
            {
                case 1:
                    //Play spell sound
                    source.PlayOneShot(spellSound[0]);
                    //Instantiate the spell particle system
                    spellclone = Instantiate(spell[0], spellLauncher.position, spellLauncher.rotation);
                    //Add force the particle system and shoot it towards the crosshair
                    spellclone.GetComponent<Rigidbody>().AddForce(Camera.main.ScreenPointToRay(Input.mousePosition).direction * speed);
                    //Once the effect is executed make the spellcast to default which is 0
                    spellcast = 0;
                    break;

                case 2:
                    source.PlayOneShot(spellSound[1]);
                    spellclone = Instantiate(spell[1], spellLauncher.position, spellLauncher.rotation);
                    spellclone.GetComponent<Rigidbody>().AddForce(Camera.main.ScreenPointToRay(Input.mousePosition).direction * speed);
                    spellcast = 0;
                    break;

                case 3:
                    source.PlayOneShot(spellSound[2]);
                    spellclone = Instantiate(spell[2], spellLauncher.position, spellLauncher.rotation);
                    spellclone.GetComponent<Rigidbody>().AddForce(Camera.main.ScreenPointToRay(Input.mousePosition).direction * speed);
                    spellcast = 0;
                    break;

                default:
                    break;
            }
        }

    }
}
