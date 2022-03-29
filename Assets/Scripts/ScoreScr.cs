using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScr : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GetComponent<TextMeshProUGUI>();
    }

    public void newScore()
    {
        scoreUI.text = "Score: " + score;
    }

}