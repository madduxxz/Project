using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image characterImage;
    public TMP_Text staminaText;
    public TMP_Text healthText;
    public TMP_Text attackText;
    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;

        characterImage.sprite = card.characterPP;

        staminaText.text = card.stamina.ToString();

        attackText.text = card.attack.ToString();
    }
}
