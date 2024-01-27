using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootMovement : MonoBehaviour
{
    bool dragging = false;
    Vector2 offset;

    private void Update()
    {
        if (dragging)
        {
            Vector2 newPos = GetMousePosition() - offset;
            transform.position = new Vector3(newPos.x, newPos.y, -1);
        }
    }

    private void OnMouseDown()
    {
        dragging = true;
        offset = GetMousePosition() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    Vector2 GetMousePosition()
    {
        return (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public bool IsDragging()
    {
        return dragging;
    }
}
