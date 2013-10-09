using UnityEngine;
using System.Collections;

public class CardManager : MonoBehaviour {

	public Texture2D ClubsTexture, SpadesTexture, DiamondsTexture, HeartsTexture;
	
#region Singleton implementation
	
	private static CardManager _instance;
	
	public static CardManager Instance
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
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
