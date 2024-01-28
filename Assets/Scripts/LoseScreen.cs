using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay;

    private void Start()
    {
        scoreDisplay.text = "Laughs Avoided: " + GameManager.score;
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene("Base Scene");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
