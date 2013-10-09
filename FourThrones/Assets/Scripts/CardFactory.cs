using UnityEngine;
using System.Collections;

public class CardFactory : MonoBehaviour {

	public GameObject CardPrefab;
	
	public Transform View;
	
	public Vector3 SpawnPoint;
	
#region Singleton implementation
	
	private static CardFactory _instance;
	
	public static CardFactory
		Instance
	{
		get
		{
			return _instance;	
		}
	}
	
	void Awake()
	{
		_instance = this;	
	}
	
#endregion
	
	public Card CreateCard()
	{
		//To-do Card Generation Algorithm here
		
		GameObject cardObject = Instantiate(CardPrefab, SpawnPoint, Quaternion.identity) as GameObject;
		
		//This sets the parent which puts us in the correct Coordinate system
		cardObject.transform.parent = View;
		
		Card card = cardObject.transform.GetComponent<Card>();
		
		card.CardValue = Random.Range(2, 10);
		
		int suit = Random.Range(1, 4);
		
		switch(suit)
		{
		case 1:
			card.CardSuit = Suit.Clubs;
			break;
		case 2:
			card.CardSuit = Suit.Diamonds;
			break;
		case 3:
			card.CardSuit = Suit.Hearts;
			break;
		case 4:
			card.CardSuit = Suit.Spades;
			break;
		}
		
		card.SetView();
		
		return card;
		
	}
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
