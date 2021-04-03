using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShownCardView : CardView
{
	public TMP_Text nameText;
	public TMP_Text attackText;
	public TMP_Text defenseText;
	public TMP_Text energyText;
	public Image elementImage;
	public Image cardImage;

    public override void InitializeData()
    {
    	nameText.text = Card.CardName;
    	attackText.text = Card.Attack.ToString();
		defenseText.text = Card.Defense.ToString();
		energyText.text = Card.Energy.ToString();
		elementImage.sprite = Card.CardElement.ElementSprite;
		cardImage.sprite = Card.CardSprite;
    }
}
