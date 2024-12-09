using UnityEngine;

public class Fade : MonoBehaviour
{
    private CanvasGroup ScreenBlack;
    private bool ScreenFade;

    private void Start()
    {
        ScreenBlack = GetComponent<CanvasGroup>();

        Invoke("ActivateBool", 3);
    }

    private void Update()
    {
        if (ScreenFade)
        {
            if (ScreenBlack.alpha >= 0)
            {
                float Duration = 0.5f;
                ScreenBlack.alpha -= Duration * Time.smoothDeltaTime;
            }

            if (ScreenBlack.alpha == 0)
            {
                ScreenFade = false;
            }
        }
    }

    private void ActivateBool()
    {
        ScreenFade = true;
    }
}
