using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public void AnimationEnd() { GameManager.animationEnd.Invoke(); }

    public void EnemyEnd() { Destroy(gameObject); }
}
