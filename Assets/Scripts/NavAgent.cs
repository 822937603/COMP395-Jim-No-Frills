using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour {

	NavMeshAgent agent;

	public Transform[] targets;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		targets[0] = GameObject.FindGameObjectWithTag ("Target").transform;
		targets[1] = GameObject.FindGameObjectWithTag ("Target2").transform;
		targets[2] = GameObject.FindGameObjectWithTag ("Target3").transform;
		targets[3] = GameObject.FindGameObjectWithTag ("Target4").transform;
		targets[4] = GameObject.FindGameObjectWithTag ("Target5").transform;
		targets[5] = GameObject.FindGameObjectWithTag ("Target6").transform;
		Choose ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Choose() {
		var chooseTarget = Random.Range (0, (targets.Length - 1));
		agent.updateRotation = false;

		agent.SetDestination (targets[chooseTarget].position);
	}

}
