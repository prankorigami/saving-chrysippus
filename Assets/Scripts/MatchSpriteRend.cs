using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchSpriteRend : MonoBehaviour
{
    private Image matchImg;
    private SpriteRenderer rendToMatch;

    private void Start()
    {
        matchImg = GetComponent<Image>();
        rendToMatch = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        matchImg.sprite = rendToMatch.sprite;
    }
}
