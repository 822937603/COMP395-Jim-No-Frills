using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeaseSpawn : MonoBehaviour {

    public bool stopSpawn;
        public SpawnCustomer spawnScript;

	// Use this for initialization
	void Start () {
        stopSpawn = false;

        GameObject player = GameObject.FindWithTag("Spawn"); //create reference for Player gameobject, and assign the variable via FindWithTag at start
        if (player != null) // if the playerObject gameObject-reference is not null - assigning the reference via FindWithTag at first frame -
        {
            spawnScript = player.GetComponent<SpawnCustomer>();// - set the PlayerController-reference (called playerControllerScript) to the <script component> of the Player gameobject (via the gameObject-reference) to have access the instance of the PlayerController script
        }
        if (player == null) //for exception handling - to have the console debug the absense of a player controller script in order for this entire code, the code in the GameController to work
        {
            Debug.Log("Cannot find SpawnCustomer script to stop spawning upon True");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   void OnTriggerStay(Collider collision)
    {
                if (collision.gameObject.CompareTag("CeaseSpawn"))
                {
                    stopSpawn = true;
                    spawnScript.StopAllCoroutines();
                }
    }
   void OnTriggerExit(Collider collision)
   {
       if (collision.gameObject.CompareTag("CeaseSpawn"))
       {
           stopSpawn = false;
           spawnScript.StartCoroutine(spawnScript.Spawn());
       }
   }
}
