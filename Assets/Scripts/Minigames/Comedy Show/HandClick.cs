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
        Instantiate(tomatoPrefab, this.transform);
        // make a prefab
    }
}
