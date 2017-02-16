using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour {

	public float delayTime;
	public float spawnWait;
	public float waveWait;
	public float customerCount;
	public GameObject customer;
	public GameObject location;

	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator Spawn () {
		
		yield return new WaitForSeconds (delayTime);
		while (true)
		{
			for (int i = 0; i < customerCount; i++) {
				Instantiate (customer, location.transform);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);


	}
		
}
}
