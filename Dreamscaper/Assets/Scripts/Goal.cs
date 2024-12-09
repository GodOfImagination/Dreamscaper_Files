using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour
{
    public int NextLevel;
    public CanvasGroup ScreenFade;
    public TextMeshProUGUI ScreenText;

    private bool CanFade;

    private void Update()
    {
        if (CanFade)
        {
            if (ScreenFade.alpha <= 1)
            {
                float Duration = 0.5f;
                ScreenFade.alpha += Duration * Time.smoothDeltaTime;
            }

            if (ScreenFade.alpha == 1)
            {
                CanFade = false;
                Invoke("LoadLevel", 3);
            }
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(NextLevel);
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
        {
            ScreenText.text = "Level Completed";
            CanFade = true;
        }
	}
}
