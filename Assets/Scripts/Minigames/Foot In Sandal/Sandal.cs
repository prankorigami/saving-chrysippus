using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandal : MonoBehaviour
{
    [SerializeField] private MinigameController controller;
    [SerializeField] GameObject bitches;
    [SerializeField] AudioSource vineBoom;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Feet" && !collision.gameObject.transform.parent.gameObject.GetComponent<FootMovement>().IsDragging())
        {
            if(UnityEngine.Random.Range(0, 100) == 69)
            {
                controller.StopTimer();
                bitches.SetActive(true);
                vineBoom.Play();
                float bitchestimer = 5f;
                while(bitchestimer >= 0)
                {
                    bitchestimer -= Time.deltaTime;
                }
                Application.Quit();
            } 
            else
            {
                controller.WinGame();
            }
        }
    }
}
