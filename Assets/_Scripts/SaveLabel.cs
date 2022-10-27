using UnityEngine;
using UnityEngine.UI;

public class SaveLabel : MonoBehaviour
{
    Text textComponent;
    Animator animatorComponent;

    void Awake()
    {
        textComponent = GetComponent<Text>();
        animatorComponent = GetComponent<Animator>();
    }

    public void ShowText(string text)
    {
        if (!animatorComponent.enabled)
        {
            animatorComponent.enabled = true;
        }
        textComponent.text = text;
        animatorComponent.Play("TextFadeOut", 0, 0);
    }
}
