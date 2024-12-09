using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    public float TransitionTime;

    private Color RandomColor;
    private Image ButtonImage;

    private void Start()
    {
        ButtonImage = GetComponent<Image>();
    }

    void Update()
    {
        if (TransitionTime <= Time.smoothDeltaTime)
        {
            ButtonImage.color = RandomColor;
            RandomColor = new Color(Random.value, Random.value, Random.value);
            TransitionTime = 1.0f;
        }
        else
        {
            ButtonImage.color = Color.Lerp(ButtonImage.color, RandomColor, Time.smoothDeltaTime / TransitionTime);
            TransitionTime -= Time.smoothDeltaTime;
        }
    }
}
