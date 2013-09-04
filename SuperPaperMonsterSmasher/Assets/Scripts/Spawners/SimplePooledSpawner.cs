using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimplePooledSpawner : MonoBehaviour {
	
	//This is will give your entire pool to fill up via the Inspector
	
	public GameObject[] EnemyPool;
	
	public List<GameObject> deadPool = new List<GameObject>();
	
	public float MinTime = 0.5f;
	public float MaxTime = 2.0f;
	
	//Cache your damn Transform so you don't have to look it up every fucking time.
	private Transform _t;
	
	void OnEnable()
	{
		EnemyController.OnKilled += HandleEnemyKilled;
	}
	
	void OnDisable()
	{
		EnemyController.OnKilled -= HandleEnemyKilled;
	}
	
	void HandleEnemyKilled( GameObject enemy, string SpawnerBaseName )
	{
		
		if(SpawnerBaseName.Equals(_t.name))
		{
			deadPool.Add(enemy);	
		}
	}
	
	void Start () 
	{
		
		_t = transform;
		
		CreatePool();
		
	}
	
	void CreatePool()
	{
		int i = 0;
		
		while(i < EnemyPool.Length)
		{
			GameObject clone = Instantiate(EnemyPool[i], _t.position, Quaternion.identity) as GameObject;
			
			EnemyPool[i] = clone;
			
			clone.transform.name = i.ToString() + clone.transform.name;
			
			EnemyController enemyController = clone.GetComponent<EnemyController>();
			enemyController.SpawnerBase = _t;
			
			deadPool.Add (clone);
			
			i++;
		}
		
		StartCoroutine(EnemyGenerator());
		
	}
	
	IEnumerator EnemyGenerator()
	{
		yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));	
		
		if(deadPool.Count > 0)
		{
			EnemyController enemyController = deadPool[0].GetComponent<EnemyController>();
			enemyController.StartEnemy();
			deadPool.RemoveAt(0);
		}
		
		StartCoroutine(EnemyGenerator());
		
	}
	

}
