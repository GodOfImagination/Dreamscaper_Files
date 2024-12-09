using UnityEngine;

public class Fade : MonoBehaviour
{
    private CanvasGroup ScreenFade;
    private bool CanFade;

    private void Start()
    {
        ScreenFade = GetComponent<CanvasGroup>();

        Invoke("ActivateBool", 3);
    }

    private void Update()
    {
        if (CanFade)
        {
            if (ScreenFade.alpha >= 0)
            {
                float Duration = 0.5f;
                ScreenFade.alpha -= Duration * Time.smoothDeltaTime;
            }

            if (ScreenFade.alpha == 0)
            {
                CanFade = false;
            }
        }
    }

    private void ActivateBool()
    {
        CanFade = true;
    }
}
