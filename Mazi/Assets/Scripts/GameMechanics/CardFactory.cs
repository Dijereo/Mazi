using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
	public GameElement FireElement;
	public GameElement WaterElement;
	public Sprite DragonSprite;
	public Sprite HydraSprite;
	public Sprite WarriorSprite;
	public Sprite TrollSprite;

	public CardData CreateCard(int cardEnum)
	{
		switch (cardEnum)
        {
        	case 1:
        		return new CardData("Dragon", 10, 2, 3, FireElement, DragonSprite);
        	case 2:
        		return new CardData("Hydra", 7, 3, 3, WaterElement, HydraSprite);
        	case 3:
        		return new CardData("Troll", 6, 4, 3, WaterElement, TrollSprite);
        	default:
        		return new CardData("Warrior", 6, 1, 3, FireElement, WarriorSprite);
        }
	}
}
