using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfCustomers2 : MonoBehaviour {

	protected List<GameObject> counter1Number = new List<GameObject>();
	public int count2=0;

	//public void OnCollisionEnter(Collision e)
	//{
		//if(e typeof GameObject)
		//{
			//if(!this.insideMe.contains(e.gameObject))
			//{
				//this.counter1Number.Add (e.gameObject);
		void OnTriggerEnter (Collider e) {

			if (e.gameObject.CompareTag("Player")) 
			{
				//this.counter1Number.Add (e.gameObject);
				count2++;
			Debug.Log ("SECOND " + count2);
			}
		//Debug.Log (count);
			//}
		//}
	}

	void OnTriggerExit (Collider e) {

		if (e.gameObject.CompareTag ("Player")) {
			//this.counter1Number.Add (e.gameObject);
			count2--;
			Debug.Log ("SECOND " + count2);
		}
	}
	//public void OnCollisionExit(Collision e)
	//{
		//if(e typeof GameObject)
		//{
			//if(this.insideMe.contains(e.gameObject))
			//{
	//	this.counter1Number.Remove(e.gameObject);
		//count--;
		//Debug.Log (count);
			//}
		//}

		//if (e.gameObject.CompareTag("Player")) 
		//{
		//	this.counter1Number.Remove (e.gameObject);
		//	count--;
		//}
		//Debug.Log (count);
	//}
		

}
