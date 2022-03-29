using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void toPlay()
    {
        SceneManager.LoadScene(2);
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void toOptions()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
