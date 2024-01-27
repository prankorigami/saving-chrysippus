using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMini : MonoBehaviour
{
    [SerializeField] private MinigameController controller;

    void Start()
    {
        if (!controller)
            Debug.LogWarning("Minigame Controller is not assigned!");
    }

    void Update()
    {
        
    }
}
