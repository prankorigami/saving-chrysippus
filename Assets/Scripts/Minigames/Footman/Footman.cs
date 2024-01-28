using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footman : MonoBehaviour
{

    [SerializeField] public MinigameController controller;

    // Update is called once per frame
    void Win()
    {
        controller.WinGame();
    }
}
