using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour {
	
	public Rigidbody rb;
	public int items;
	NavMeshAgent agent;
	public float speed;
	public Transform expressCounter;

	public Transform[] targets;

	public bool stopSpawn;

	// Use this for initialization
	void Start () {
		stopSpawn = false;
		rb = GetComponent<Rigidbody> ();
		items = Random.Range(1, 12);
		expressCounter = GameObject.FindGameObjectWithTag ("Express").transform;
		agent = GetComponent<NavMeshAgent> ();
		Vector3 speed = GetComponent<NavMeshAgent> ().velocity;
		targets[0] = GameObject.FindGameObjectWithTag ("Target").transform;
		targets[1] = GameObject.FindGameObjectWithTag ("Target2").transform;
		targets[2] = GameObject.FindGameObjectWithTag ("Target3").transform;
		targets[3] = GameObject.FindGameObjectWithTag ("Target4").transform;
		targets[4] = GameObject.FindGameObjectWithTag ("Target5").transform;
		targets[5] = GameObject.FindGameObjectWithTag ("Target6").transform;
		targets[6] = GameObject.FindGameObjectWithTag ("Express").transform;
		Choose ();
	}
	
	// Update is called once per frame
	void Update () {
		if (items == 1 || items == 2) {
			agent.SetDestination (targets[6].position);
		}
	}

	void FixedUpdate() {
		rb.AddForce (transform.forward * speed);
	}

	void OnCollisionEnter (Collision collision) {

		if (collision.gameObject.CompareTag("Counter1")) 
		{
			speed = 0.0f;
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
			speed = 0.0f;
			Invoke ("Restart", items);
			items = 0;
		}

	}

	void Restart()
	{
		this.GetComponent<BoxCollider>().enabled = false;
		speed = -20.0f;
		rb.AddForce(transform.forward * speed);
		Invoke("ColliderRestart", 2.0f);
	}

	void ColliderRestart()
	{
		this.GetComponent<BoxCollider>().enabled = true;
	}

	void Choose() {
		var chooseTarget = Random.Range (0, (targets.Length - 1));
		agent.updateRotation = false;

		agent.SetDestination (targets[chooseTarget].position);
	}

}
