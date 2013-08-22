using UnityEngine;
using System.Collections;

public class StartScreenController : MonoBehaviour {

	bool _isMobile = false;
	bool _startNextLevelLock = false;
	
	void Start () 
	{
		if(!Application.isEditor && !Application.isWebPlayer)
		{
			_isMobile = true;	
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(_isMobile)
		{
			MobileUpdate();
		} else {
			EditorUpdate();
		}
	}
	
	void MobileUpdate()
	{
		if(Input.touchCount > 0 && !_startNextLevelLock)
		{
			
			LockAndLoadGame();
			
		}
	}
	
	void EditorUpdate()
	{
		if(Input.GetMouseButtonDown(0) && !_startNextLevelLock)
		{
			
			LockAndLoadGame();
			
		}
	}
	
	void LockAndLoadGame()
	{
		_startNextLevelLock = true;	
		
		//Look at File > Build Settings > Scenes In Build to make sure this is working
		
		Application.LoadLevel("GameLevel");	
	}
}
