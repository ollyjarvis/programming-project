using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !pauseMenu.gameObject.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.gameObject.SetActive(true);
            CharacterController cc = GetComponent<CharacterController>();
            cc.enabled = false; 
        }
        else if (Input.GetButtonDown("Cancel") && pauseMenu.gameObject.activeInHierarchy )
        {
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.gameObject.SetActive(false);
            CharacterController cc = GetComponent<CharacterController>();
            cc.enabled = true; 
        }
    }
}
