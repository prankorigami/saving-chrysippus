using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTowardsLoc : MonoBehaviour
{
    private Vector3 startLoc;
    [SerializeField] private Vector3 endLoc;

    private void Start()
    {
        startLoc = transform.localPosition;
    }

    public void UpdatePosition(float t)
    {
        Debug.Log(t);
        //Debug.Log(Vector3.Lerp(startLoc, endLoc, t));
        transform.localPosition = Vector3.Lerp(startLoc, endLoc, t);
    }
}
