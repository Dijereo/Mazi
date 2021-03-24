using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardShown : MonoBehaviour
{
	public string cardName;
	public int attack;
	public int defense;
	public int energy;
	public Sprite cardElement;
	public Sprite cardSprite;
	public TMP_Text nameText;
	public TMP_Text attackText;
	public TMP_Text defenseText;
	public TMP_Text energyText;
	public Image elementImage;
	public Image cardImage;
	// public Sprite back = ...;

    void Start()
    {
    	nameText.text = cardName;
    	attackText.text = attack.ToString();
		defenseText.text = defense.ToString();
		energyText.text = energy.ToString();
		elementImage.sprite = cardElement;
		cardImage.sprite = cardSprite;
    }
}
