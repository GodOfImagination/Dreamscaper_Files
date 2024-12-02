using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject TitleScreen;
    public GameObject SelectionScreen;

    private bool IsLocked = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (IsLocked)
            {
                IsLocked = false;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                IsLocked = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void ButtonPlay()
    {
        TitleScreen.SetActive(false);
        SelectionScreen.SetActive(true);
    }

    public void LoadScene(int Number)
    {
        SceneManager.LoadScene(Number);
    }
}
