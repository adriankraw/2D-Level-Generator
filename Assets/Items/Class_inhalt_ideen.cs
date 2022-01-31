using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classinhaltideen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    class Item
	{
		string name;
		string description;	    //flavour text oder item beschreibung was es macht
		string owner;		    //charaktergebundene items vlt		

		int maxStack;
		int stackSize;
		int damageValue;
		int slot;		        //inventar slot oder spezifischer slot.


		double useSpeed; 	    //wie schnell kann es benutzt werden?
		double cooldown;	
		double duration;	    //wenn duration
		double maxDuration;	
		double sellValue;	    //verkaufswert
		double position;	    //wenn item gedroppt ist x und y coordinaten


		bool consumable;	    //ist es eine waffe/rüstung/accesorie oder ein verbrauchbares item
		bool friendlyfire;	
		bool itemKnown;		    //vlt für collection eintrag
		bool dropable;		    //items das monster benutzt; gold von spieler, kann durch andere items verändert werden
		

	}
}
