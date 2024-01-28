using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HandClick : MonoBehaviour
{
    //[SerializeField] private MinigameController controller;
    [SerializeField] private Sprite hand_alt;
    [SerializeField] private GameObject tomatoPrefab;
    [SerializeField] private Sprite tomato_splat;
    private bool clicked = false;
    private float tomatoTimer = -1;
    private Vector3 tomatoDirection = Vector3.zero;
    private GameObject tomato = null;
    [SerializeField] private AudioClip splat;
    [SerializeField] private AudioClip wooosh;
    public ComedyShow game;

    private void Update()
    {
        if (tomato != null && tomatoTimer > 0) {
            tomatoTimer -= Time.deltaTime;
            tomato.transform.position += Time.deltaTime * tomatoDirection;
            tomato.transform.Rotate(0f, 0f, 630f*Time.deltaTime);
            if (tomatoTimer < 0) {
                GetComponent<AudioSource>().Stop();
                tomatoDirection = Vector3.zero;
                //GameObject.Destroy(tomato);
                tomato.GetComponentInChildren<SpriteRenderer>().sprite = tomato_splat;
                // todo: add splat
                GetComponent<AudioSource>().PlayOneShot(splat);
                game.splat();
            }
        }
    }
    private void OnMouseDown()
    {
        if (!clicked)
        {
            clicked = true;
            GetComponent<SpriteRenderer>().sprite = hand_alt; // change later to hand_alternate
            throwTomato(); // make a tomato throw
        }
    }
    private void throwTomato() {

        GetComponent<AudioSource>().clip = wooosh;
        GetComponent<AudioSource>().Play();
        tomato = Instantiate(tomatoPrefab, this.transform);
        tomatoDirection = new Vector3(-0.4f + 0.8f*Random.value, 0.5f + 0.7f*Random.value, -2f) - this.transform.position;
        tomatoTimer = 1f;
        // make a prefab
    }
}
