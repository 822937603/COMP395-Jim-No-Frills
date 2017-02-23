using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLine : MonoBehaviour {

    public bool stopISTrigger = false;
    public bool stopNOTTrigger;
    public Movement  moveScript;

	// Use this for initialization
	void Start () {
        GameObject stopline = GameObject.FindWithTag("Player"); //create reference for Player gameobject, and assign the variable via FindWithTag at start
        if (stopline != null) // if the playerObject gameObject-reference is not null - assigning the reference via FindWithTag at first frame -
        {
            moveScript = stopline.GetComponent<Movement>();// - set the PlayerController-reference (called playerControllerScript) to the <script component> of the Player gameobject (via the gameObject-reference) to have access the instance of the PlayerController script
        }
        if (stopline == null) //for exception handling - to have the console debug the absense of a player controller script in order for this entire code, the code in the GameController to work
        {
            Debug.Log("Cannot find SpawnCustomer script for StopLine");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTrggerEnter(Collider stopline)
    {
        if (stopline.gameObject.CompareTag("Player"))
        {
            /*
            if (stopline != null) // if the playerObject gameObject-reference is not null - assigning the reference via FindWithTag at first frame -
            {
                moveScript = stopline.GetComponent<Movement>();// - set the PlayerController-reference (called playerControllerScript) to the <script component> of the Player gameobject (via the gameObject-reference) to have access the instance of the PlayerController script
            }
            if (stopline == null) //for exception handling - to have the console debug the absense of a player controller script in order for this entire code, the code in the GameController to work
            {
                Debug.Log("Cannot find SpawnCustomer script for StopLine");
            }*/
            stopISTrigger = true;
            this.moveScript.force = 5.0f;
        }
    }

    void OnTrggerStay(Collider stopline)
    {
        if (stopline.gameObject.CompareTag("StopLine"))
        {
            /*
            if (stopline != null) // if the playerObject gameObject-reference is not null - assigning the reference via FindWithTag at first frame -
            {
                moveScript = stopline.GetComponent<Movement>();// - set the PlayerController-reference (called playerControllerScript) to the <script component> of the Player gameobject (via the gameObject-reference) to have access the instance of the PlayerController script
            }
            if (stopline == null) //for exception handling - to have the console debug the absense of a player controller script in order for this entire code, the code in the GameController to work
            {
                Debug.Log("Cannot find SpawnCustomer script for StopLine");
            }*/
            stopISTrigger = true;
            this.moveScript.force = 5.0f;
        }
    }
    void OnTrggerExit(Collider stopline)
    {
        if (stopline.gameObject.CompareTag("StopLine"))
        {
            stopISTrigger = false;
            this.moveScript.force = -20.0f;
        }
    }
    
    void OnCollisionEnter(Collision stopline)
    {
        if (stopline.gameObject.CompareTag("Player"))
        {
            if (stopline != null) // if the playerObject gameObject-reference is not null - assigning the reference via FindWithTag at first frame -
            {
                moveScript = stopline.gameObject.GetComponent<Movement>();
            }
            else if (stopline == null) //for exception handling - to have the console debug the absense of a player controller script in order for this entire code, the code in the GameController to work
            {
                Debug.Log("Cannot find SpawnCustomer script for StopLine");
            }
            stopISTrigger = true;
            //this.moveScript.force = 0.0f;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
    /*
    void OnCollisionExit(Collision stopline)
    {
        if (stopline.gameObject.CompareTag("Player"))
        {
            this.moveScript.force = -20.0f;
            stopISTrigger = false;
        }
    }*/
}
