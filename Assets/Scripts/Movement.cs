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
	}

    void Restart()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        force = -20.0f;
        rb.AddForce(transform.forward * force);
    }
}
