﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float force;
	public Rigidbody rb;
    public int items;
	public Transform expressCounter;
	//NumberOfCustomers1 NUM1;
	//NumberOfCustomers2 NUM2;

	public Transform Lane2;

    public bool stopSpawn;

	// Use this for initialization
	void Start () {
        stopSpawn = false;
		rb = GetComponent<Rigidbody> ();
        items = Random.Range(1, 12);
		expressCounter = GameObject.FindGameObjectWithTag( "Express" ).transform;
		Lane2 = GameObject.FindGameObjectWithTag ("Counter2").transform;

		//GameObject Num1 = GameObject.Find ("NumberCounter1");
		//NumberOfCustomers1 Num1Script = Num1.GetComponent<NumberOfCustomers1> ();

		//GameObject Num2 = GameObject.Find("NumberCounter2");
		//NumberOfCustomers2 Num2Script = Num2.GetComponent<NumberOfCustomers2> ();

		//if (Num1Script.count > Num2Script.count2) {
		//	this.transform.position = Vector3.MoveTowards(this.transform.position,expressCounter.position,2.0f);
		//}
        
    }
	
	// Update is called once per frame
	void Update () {

		GameObject Num1 = GameObject.Find ("NumberCounter1");
		NumberOfCustomers1 Num1Script = Num1.GetComponent<NumberOfCustomers1> ();

		GameObject Num2 = GameObject.Find("NumberCounter2");
		NumberOfCustomers2 Num2Script = Num2.GetComponent<NumberOfCustomers2> ();


		if (Num1Script.count > Num2Script.count2) {
			this.transform.position = Vector3.MoveTowards(this.transform.position,expressCounter.position,2.0f);
		}

		//LaneCompare ();

		if (items == 1 || items == 2) 
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position,expressCounter.position,2.0f);

			//Vector3 targetdir = expressCounter.position - this.transform.position;
			//Vector3 newDir = Vec	tor3.RotateTowards(transform.forward,targetdir,this.force,0.0f);
			//this.transform.rotation = Quaternion.LookRotation(newDir);


			//transform.LookAt (expressCounter);
			//move constantly towards player
			//float step = force * Time.deltaTime;
			//transform.position = Vector3.MoveTowards(transform.position, expressCounter.position, step);
		}
	}

	void FixedUpdate() {
		rb.AddForce (transform.forward * force);
	}

	void OnCollisionEnter (Collision collision) {

		if (collision.gameObject.CompareTag("Counter1")) 
		{
            force = 0.0f;
            Invoke("Restart", items);
		}
        if (collision.gameObject.CompareTag("CustomerDepart"))
        {
            this.GetComponent<BoxCollider>().enabled = true;
            this.transform.rotation = Quaternion.Euler(1.0f, 0, 0);
            //rb.AddForce(transform.up * force);
        }

		if (collision.gameObject.CompareTag("Death")) {
			Destroy (this.gameObject);
		}
		if (collision.gameObject.CompareTag("Express")) {
			force = 0.0f;
			Invoke("Restart", items);
			items = 0;
		}
		if (collision.gameObject.CompareTag ("Player")) {
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ; 
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation; 
		}

    }
    

    void Restart()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        force = -20.0f;
        rb.AddForce(transform.forward * force);
        Invoke("ColliderRestart", 2.0f);
    }

    void ColliderRestart()
    {
        this.GetComponent<BoxCollider>().enabled = true;
    }

	void LaneCompare()
	{
		//int Counter1Number = NUM1.count;
		//int Counter2Number = NUM2.count2;

		//if (Num1Script > Counter2Number) {
		//	this.transform.position = Vector3.MoveTowards(this.transform.position,Lane2.position,2.0f);
		//}
			
	}

	//void PauseCustomer()
	//{
	//	force = 0.0f;
	//}
                 
}
