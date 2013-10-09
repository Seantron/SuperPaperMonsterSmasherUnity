using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public delegate void MenuEvent();
	public static event MenuEvent OnSingle, OnEndless, OnKings, OnTutorial, OnThemes;
	
	public GUITexture SingleButton, EndlessButton, KingsButton, TutorialButton, ThemesButton;
	
	void OnEnable()
	{
		InputManager.OnInput += HandleInput;
	}
	
	void OnDisable()
	{
		InputManager.OnInput -= HandleInput;
	}
	
	void HandleInput( Vector2 pos )
	{
		if(SingleButton.HitTest(pos))
		{
			if(OnSingle != null)
			{
				OnSingle();	
			}
			
		} else if(EndlessButton.HitTest(pos))
		{
			
			if(OnEndless != null)
			{
				OnEndless();	
			}
			
		} else if(KingsButton.HitTest(pos))
		{
			
			if(OnKings != null)
			{
				OnKings();	
			}
			
		} else if(TutorialButton.HitTest(pos))
		{
			
			if(OnTutorial != null)
			{
				OnTutorial();	
			}
			
		} else if(ThemesButton.HitTest(pos))
		{
			
			if(OnThemes != null)
			{
				OnThemes();	
			}
			
		}
	}
}
