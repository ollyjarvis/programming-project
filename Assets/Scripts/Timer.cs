using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer;
    private float truncated;
    private float minutes;
    private float seconds;

    public TextMeshProUGUI timerUI;

    public Canvas paused;

    // Start is called before the first frame update
    void Start()
    {
        timerUI = GetComponent<TextMeshProUGUI>();
        timer = 300;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            if (!paused.gameObject.activeInHierarchy)
            {
                timer -= Time.deltaTime;
                newTime();
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }

    void newTime()
    {
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        timerUI.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
