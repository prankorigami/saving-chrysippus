using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandal : MonoBehaviour
{
    [SerializeField] private MinigameController controller;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Feet" && !collision.gameObject.transform.parent.gameObject.GetComponent<FootMovement>().IsDragging())
        {
            controller.WinGame();
        }
    }
}
