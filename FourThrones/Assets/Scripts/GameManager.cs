using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform Menu;
	
	public Vector2 TopLeftCard, TopRightCard, BottomLeftCard, BottomRightCard, CardInPlay;
	
	void OnEnable()
	{
		MenuController.OnSingle += HandleSingleGameStarted;
	}
	
	void OnDisable()
	{
		MenuController.OnSingle -= HandleSingleGameStarted;
	}
	
	void HandleSingleGameStarted()
	{
		StartGame();	
	}
	
	void Start () 
	{
		Go.defaultEaseType = GoEaseType.ExpoInOut;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void StartGame()
	{
		
		GoTween tween = Go.to( Menu, 0.75f, new GoTweenConfig()
			.position( new Vector3( 0, 1, 0 )));
		
		Invoke("DealAllCards", 1.0f);
	}
	
	void DealAllCards()
	{
		StartCoroutine(Deal4CardsAnimation());
	}
	
	IEnumerator Deal4CardsAnimation()
	{
		int i = 0;
		
		while(i < 5)
		{
			Card card = CardFactory.Instance.CreateCard();
			
			Vector2 pos = Vector2.zero;
			
			switch(i)
			{
			case 0:
				pos = TopLeftCard;
				break;
			case 1:
				pos = TopRightCard;
				break;
			case 2:
				pos = BottomLeftCard;
				break;
			case 3:
				pos = BottomRightCard;
				break;
			case 4:
				pos = CardInPlay;
				break;
			}
			
			GoTween tween = Go.to( card.transform, 0.35f, new GoTweenConfig()
			.position( pos ));
			
			yield return new WaitForSeconds(0.35f);
			i++;
		}
	}
	
	void DealOneCard()
	{
		
	}
}
