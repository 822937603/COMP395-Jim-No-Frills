using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour {
	
	public Rigidbody rb;
	public int items;
	NavMeshAgent agent;
    //public Vector3 speed = GetComponent<NavMeshAgent>().velocity;
    public float speed;
    public Vector3 destination;
	public Transform expressCounter;
	public Transform deathTarget;
	public Transform[] targets;

	public bool stopSpawn;

	// Use this for initialization
	void Start () {
		stopSpawn = false;
		rb = GetComponent<Rigidbody> ();
		items = Random.Range(1, 12);
		expressCounter = GameObject.FindGameObjectWithTag ("Express").transform;
		agent = GetComponent<NavMeshAgent> ();
		deathTarget = GameObject.FindGameObjectWithTag ("Die").transform;
		destination = agent.destination;
		targets[0] = GameObject.FindGameObjectWithTag ("Target").transform;
		targets[1] = GameObject.FindGameObjectWithTag ("Target2").transform;
		targets[2] = GameObject.FindGameObjectWithTag ("Target3").transform;
		targets[3] = GameObject.FindGameObjectWithTag ("Target4").transform;
		targets[4] = GameObject.FindGameObjectWithTag ("Target5").transform;
		targets[5] = GameObject.FindGameObjectWithTag ("Target6").transform;
		targets[6] = GameObject.FindGameObjectWithTag ("Express").transform;
		Choose ();

		if (items == 1 || items == 2) {
			agent.SetDestination (targets[6].position);
		}

        Invoke("Slowdown", 6.5f);
        Invoke("Speedup", 7.5f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	/*void FixedUpdate() {
		rb.AddForce (transform.forward * speed);
	}*/

	void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            agent.speed = 0.0f;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            agent.speed = 30.0f;
            Invoke("Speedup", 1.0f);
            /*agent.speed = 0.0f;
            agent.angularSpeed = 0.0f;
            Invoke("Speedup", 1.0f);*/
            //agent.speed = 100.0f;
        }

		if (collision.gameObject.CompareTag("Counter1")) 
		{
			agent.speed = 0.0f;
            agent.angularSpeed = 0.0f;
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
			Invoke("Restart", items);
		}

		if (collision.gameObject.CompareTag("Death")) {
			Destroy (this.gameObject);
		}

		if (collision.gameObject.CompareTag("Express")) {
			agent.speed = 0.0f;
            agent.angularSpeed = 0.0f;
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
			Invoke ("Restart", items);
			items = 0;
		}

	}
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            agent.speed = 0.0f;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            agent.speed = 30.0f;
            Invoke("Speedup", 7.0f);

            //Invoke("Speedup", 1.0f);
            /*agent.speed = 0.0f;
            agent.angularSpeed = 0.0f;
            Invoke("Speedup", 1.0f);*/
            //agent.speed = 100.0f;
        }
    }
    /*void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            agent.speed = 80.0f;
            agent.angularSpeed = 120.0f;
            
        }
    }*/
    /*public void Constraint()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }*/
    public void Slowdown()
    {
        agent.speed = 0.0f;
        agent.angularSpeed = 0.0f;
    }
    public void Speedup()
    {
        agent.speed = 80.0f;
        agent.angularSpeed = 120.0f;
    }
    public void Speedup2()
    {
        agent.speed = 100.0f;
        agent.angularSpeed = 120.0f;
    }
	void Restart()
	{
		this.GetComponent<BoxCollider>().enabled = false;
        agent.speed = 80.0f;
        agent.angularSpeed = 120.0f;
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
		//rb.AddForce(transform.forward * speed);
		Invoke("ColliderRestart", 2.0f);
		destination = deathTarget.position;
		agent.destination = destination;
	}

	void ColliderRestart()
	{
		this.GetComponent<BoxCollider>().enabled = true;
	}

	void Choose() {
		var chooseTarget = Random.Range (0, (targets.Length - 1)); //lane-1
		agent.updateRotation = false;
		destination = targets [chooseTarget].position;
		agent.destination = destination;
	}

}
