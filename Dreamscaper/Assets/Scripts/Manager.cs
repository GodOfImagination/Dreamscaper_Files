using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject ScreenTitle;
    public GameObject ScreenSelection;
    public GameObject ScreenPause;

    private bool IsLocked = false;
    private bool IsPaused = false;

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                IsPaused = false;
                ScreenPause.SetActive(false);
            }
            else
            {
                IsPaused = true;
                ScreenPause.SetActive(true);
            }
        }
    }

    public void ButtonPlay()
    {
        ScreenTitle.SetActive(false);
        ScreenSelection.SetActive(true);
    }

    public void LoadScene(int Number)
    {
        SceneManager.LoadScene(Number);
    }
}
