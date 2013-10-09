using UnityEngine;
using System.Collections;

public enum Suit { Clubs, Spades, Diamonds, Hearts };

public enum Type { Number, Jack, Queen, King, Ace };

public class Card : MonoBehaviour {
	
	public Suit CardSuit;
	
	public Type CardType;
	
	public int CardValue = 0;
	
	public GUIText NumberView;
	public GUITexture SuitView;

	// Use this for initialization
	void Start () 
	{
		SetView();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetView()
	{
		switch(CardSuit)
		{
		case Suit.Clubs:
			
			SuitView.texture = CardManager.Instance.ClubsTexture;
			SuitView.color = Color.black;
			
			NumberView.text = CardValue.ToString();
			
			break;
		case Suit.Spades:
			
			SuitView.texture = CardManager.Instance.SpadesTexture;
			SuitView.color = Color.black;
			
			NumberView.text = CardValue.ToString();
			
			break;
		case Suit.Diamonds:
			
			SuitView.texture = CardManager.Instance.DiamondsTexture;
			SuitView.color = Color.red;
			
			NumberView.text = CardValue.ToString();
			
			break;
		case Suit.Hearts:
			
			SuitView.texture = CardManager.Instance.DiamondsTexture;
			SuitView.color = Color.red;
			
			NumberView.text = CardValue.ToString();
			
			break;
		}
	}
}
