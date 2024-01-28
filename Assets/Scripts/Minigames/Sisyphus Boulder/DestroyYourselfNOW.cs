using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyYourselfNOW : MonoBehaviour
{
    [SerializeField] private float timeLeftOnThisPlane = 1f;

    private void Update()
    {
        timeLeftOnThisPlane -= Time.deltaTime;

        if (timeLeftOnThisPlane < 0f)
            Destroy(gameObject);
    }
}
