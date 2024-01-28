using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    bool dragging = false;
    Vector2 offset;

    // Update is called once per frame
    private void Update()
    {
        if(dragging)
        {
            Vector2 newPos = GetMousePosition() - offset;
            transform.position = new Vector2(newPos.x, newPos.y);
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
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public bool IsDragging()
    {
        return dragging;
    }
}
