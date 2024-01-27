using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandal : MonoBehaviour
{
    [SerializeField] private MinigameController controller;
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Feet" && !collision.gameObject.GetComponent<FootMovement>().IsDragging())
        {
            controller.WinGame();
        }
    }
}
