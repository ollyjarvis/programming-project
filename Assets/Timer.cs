using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer;
    private float truncated;
    private float minutes;
    private float seconds;

    public TextMeshProUGUI timerUI;

    // Start is called before the first frame update
    void Start()
    {
        timerUI = GetComponent<TextMeshProUGUI>();
        timer = 300;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        newTime();
    }

    void newTime()
    {
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        timerUI.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
