using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    CardInfo info = new CardInfo;

    public SpriteRenderer spriteRendererComponent;
    public Image healthBarImageComponent;
    public Text nameTextComponent;
    public Text healthBarNumberTextComponent;

    void Start()
    {
        SetCard();
    }

    public void SetCard()
    {
        name = info.cardName;
        nameTextComponent.text = info.cardName;
        transform.position = info.cardPosition;
        spriteRendererComponent.transform.rotation = info.cardRotation;
        spriteRendererComponent.sprite = info.cardSprite;
        spriteRendererComponent.color = info.cardColor;
        healthBarImageComponent.fillAmount = info.currentHealth / info.totalHealth;
        healthBarNumberTextComponent.text = info.currentHealth + "/" + info.totalHealth;
    }

    void Update()
    {
        info.cardPosition = transform.position;
        info.cardRotation = spriteRendererComponent.transform.rotation;
        info.cardColor = spriteRendererComponent.color;
    }
}