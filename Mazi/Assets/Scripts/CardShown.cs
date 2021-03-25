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
	public bool isAttacker;
	public Sprite cardElement;
	public Sprite cardSprite;
	public Gameplay game;
	public TMP_Text nameText;
	public TMP_Text attackText;
	public TMP_Text defenseText;
	public TMP_Text energyText;
	public Image elementImage;
	public Image cardImage;
	// public Sprite back = ...;

    void Start()
    {
    	UpdateAttributes();
    }

    public void SetAttributes(string name, int atk, int def, int en, bool isatk,
    	Sprite el, Sprite sprite, Gameplay g)
    {
    	cardName = name;
    	attack = atk;
    	defense = def;
    	energy = en;
    	cardElement = el;
    	isAttacker = isatk;
    	cardSprite = sprite;
    	game = g;
    	UpdateAttributes();
    }

    public void UpdateAttributes()
    {
    	nameText.text = cardName;
    	attackText.text = attack.ToString();
		defenseText.text = defense.ToString();
		energyText.text = energy.ToString();
		elementImage.sprite = cardElement;
		cardImage.sprite = cardSprite;
    }

	void OnMouseDown()
	{
		Debug.Log("Hello");
		game.opponentHealthText.text = "15";
		if (isAttacker)
		{
			game.SetAttacker(this);
		}
		else {
			game.SetDefender(this);
			game.Attack();
		}
	}
}
