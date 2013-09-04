using UnityEngine;
using System.Collections;

public enum EnemyType{ Archer, Pikeman, Shield, Knight };

public class EnemyBase 
{
	private int _health = 0;
	private float _speed = 0.0f;
	private int _id = 0;
	private EnemyType _enemyType;
	
	

	public EnemyBase()
	{
		//Constructor	
	}
	
	public virtual void SetHealth()
	{
			
	}
	
	public virtual void SetSpeed()
	{
		
	}
	
	public virtual void SetID()
	{
		
	}
	
	public virtual void SetEnemyType()
	{
		
	}
	
	public virtual int GetHealth()
	{
		return _health;	
	}
	
	public virtual float GetSpeed()
	{
		return _speed;	
	}
	
	public virtual int GetID()
	{
		return _id;
	}
	
	public virtual EnemyType GetEnemyType()
	{
		return _enemyType;	
	}
	
	
}
