using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDepart : MonoBehaviour {

    public GameObject player;

    void OnTriggerStay(Collider otherGameObject)
    {

        if (otherGameObject.CompareTag("Player"))
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
