using UnityEngine;
using System.Collections;

public enum EnemyEventType{ Killed, Started, HitMonster };

public class EnemyController : MonoBehaviour {
	
	public delegate void EnemyEvent( GameObject enemy, string SpawnerBaseName );
	public static event EnemyEvent OnKilled, OnStarted, OnHitMonster;
	

	public Transform SpawnerBase;
	
	private Transform _t;
	
	bool isLeftEnemy = false;
	
	bool isDead = true;
	
	public EnemyType Type;
	
	public float SPEED = 0.25f;
	
	void Start () 
	{
		_t = transform;
		
		if(_t.position.x < 0.0f)
		{
			isLeftEnemy = true;	
		} else {
			_t.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);	
		}
		
		
	}
	
	
	//If you want your shit to work right cross platform, call your moment logic on the Physics update
	
	void FixedUpdate()
	{
		if(!isDead)
		{
			if(isLeftEnemy)
			{
				_t.position += new Vector3(1.0f * Mathf.PingPong(Time.time, SPEED), 0.0f, 0.0f);
			} else {
				_t.position -= new Vector3(1.0f * Mathf.PingPong(Time.time, SPEED), 0.0f, 0.0f);
			}
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.transform.name.Equals("DeathWall") && !isDead)
		{
			Debug.Log ("Hit Wall!");
			
			isDead = true;
			_t.position = SpawnerBase.position;
			
			if(OnKilled != null)
			{
				OnKilled( this.gameObject, SpawnerBase.name );	
			}
		}
	}
	
	public void StartEnemy()
	{
		isDead = false;	
	}
	
	
}
