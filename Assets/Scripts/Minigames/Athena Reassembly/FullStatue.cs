using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullStatue : MonoBehaviour
{
    [SerializeField] private MinigameController controller;
    [SerializeField] private Collider2D BodyColliderRight;
    [SerializeField] private Collider2D BodyColliderLeft;
    [SerializeField] private Collider2D SpearCollider;
    [SerializeField] private Collider2D ShieldCollider;

    void Update()
    {
        if(BodyColliderRight.IsTouching(ShieldCollider) && BodyColliderLeft.IsTouching(SpearCollider))
        {
            controller.WinGame();
        }
    }
}
