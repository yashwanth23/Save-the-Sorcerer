using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**************************************************************************************************************************************************************************************
 This script is for identifying the spell cast by the user through Watson Speech to Text SDK and assigning a value to a variable that keeps check on the type of spell that was casted
 **************************************************************************************************************************************************************************************/
public class ChangeSpell : MonoBehaviour {

    string theSpell;
    public Text textUI;
    public static int spellChange = 0;

	void Update () {

        //Assign the text that is linked to Watson SDK speech to text 
        theSpell = textUI.text;

        //The spells are inspired from Harry potter and these are used to create different effects
        //IBM Watson SDK is bad at detecting accents. The current version was unable to detect Indian accent and hence I had to hardcode it in order to generalize and be able to detect multiple accents
        //Also, the spells are not out of the usual dictionary words and so they have to go with pronunciation. All the spells are split into various pronunciations and all the words that arise are coded in for detection

        //This spell is "Expeliamus"
        if (theSpell.Contains("yes") || theSpell.Contains("yeah") || theSpell.Contains("experience") || theSpell.Contains("expedia miss") || theSpell.Contains("much"))
        {
            //Assign the spell value which will be later used to show visuals
            spellChange = 1;
        }

        //This spell is "Ridiculous"
        else if (theSpell.Contains("need") || theSpell.Contains("ridiculous") || theSpell.Contains("this") || theSpell.Contains("ready") || theSpell.Contains("really") || theSpell.Contains("indeed")) 
        {
            spellChange = 2;
        }

        //This spell is "Vingadiyam Leviyosa"
        else if (theSpell.Contains("when") || theSpell.Contains("have") || theSpell.Contains("thank") || theSpell.Contains("guardian"))
        {
            spellChange = 3;
        }
    }
}
