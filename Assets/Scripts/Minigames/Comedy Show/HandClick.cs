using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandClick : MonoBehaviour
{
    //[SerializeField] private MinigameController controller;
    [SerializeField] private Sprite hand_alt;
    [SerializeField] private GameObject tomatoPrefab;
    private bool clicked = false;
    private float tomatoTimer = -1;
    private Vector3 tomatoDirection = Vector3.zero;
    private GameObject tomato = null;

    private void Update()
    {
        if (tomato != null && tomatoTimer > 0) {
            tomatoTimer -= Time.deltaTime;
            tomato.transform.position += Time.deltaTime * tomatoDirection;
            tomato.transform.Rotate(0f, 0f, 630f*Time.deltaTime);
            if (tomatoTimer < 0) {
                GameObject.Destroy(tomato);
                tomato = null;
                tomatoDirection = Vector3.zero;
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
        tomato = Instantiate(tomatoPrefab, this.transform);
        tomatoDirection = new Vector3(0f, 1.3f, 0f) - this.transform.position;
        tomatoDirection.z = 0f;
        tomatoTimer = 1f;
        // make a prefab
    }
}
