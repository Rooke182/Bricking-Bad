using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            Debug.Log("Player Entered Collision");
            other.GetComponent<NavMeshAgent>().speed = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            Debug.Log("Player Entered Collision");
            other.GetComponent<NavMeshAgent>().speed = 5;
        }
    }
}
