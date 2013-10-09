using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	
	public delegate void InputEvent( Vector2 pos );
	public static event InputEvent OnInput;

	bool _isMobile = true;

	
	void Start () 
	{
#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
		
		_isMobile = false;
		
#endif
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(_isMobile)
		{
			TouchUpdate();
		} else {
			MouseUpdate();
		}
	}
	
	void MouseUpdate()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(OnInput != null)
			{
				OnInput(Input.mousePosition);	
			}
		} 
		
	}
	
	void TouchUpdate()
	{
		if(Input.touchCount > 0)
		{
			if(OnInput != null)
			{
				OnInput(Input.touches[0].position);	
			}
		}
	}
}
