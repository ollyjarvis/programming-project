using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeSettings : MonoBehaviour
{
    public TMP_InputField newSens;
    private float newSensValue;

    public void changeSens()
    {
        newSensValue = float.Parse(newSens.text);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("sens", newSensValue);
    }

}