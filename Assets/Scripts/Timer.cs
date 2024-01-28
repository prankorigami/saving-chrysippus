using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private MinigameController controller;
    [SerializeField] Transform timer;
    float startTime;

    private void Start()
    {
        startTime = controller.GetStartTimer();
    }
    // Update is called once per frame
    void Update()
    {
        timer.localScale = new Vector3(Mathf.Lerp(12, 0, controller.GetTimer() / startTime), 0.3f, 0);
    }
}
