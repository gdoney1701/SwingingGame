using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollector : MonoBehaviour
{
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerMovement>().targetHandler(true, other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerMovement>().targetHandler(false, other.gameObject);
    }
}
