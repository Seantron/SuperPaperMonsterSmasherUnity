using UnityEngine;
using System.Collections;

public class TimedDestroyer : MonoBehaviour {

	public float TimeDelay = 8.0f;
	
	void Start () 
	{
		StartCoroutine(DelayDestroy());
	}
	
	IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(TimeDelay);
		Destroy (this.gameObject);
	}
}
