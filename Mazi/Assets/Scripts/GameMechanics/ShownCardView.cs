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

    public override void InitializeStats()
    {
    	nameText.text = Stats.CardName;
    	attackText.text = Stats.Attack.ToString();
		defenseText.text = Stats.Defense.ToString();
		energyText.text = Stats.Energy.ToString();
		elementImage.sprite = Stats.CardElement.ElementSprite;
		cardImage.sprite = Stats.CardSprite;
    }
}
