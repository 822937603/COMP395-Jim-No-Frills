using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float force;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		rb.AddForce (transform.forward * force);
	}

	void OnCollisionEnter (Collision collision) {

		if (collision.gameObject.CompareTag("Counter1")) 
		{
            force = 0.0f;
            Invoke("Restart", 5.0f);
		}
        if (collision.gameObject.CompareTag("CustomerDepart"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            this.transform.rotation = Quaternion.Euler(1.0f, 0, 0);
            //rb.AddForce(transform.up * force);
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

}
