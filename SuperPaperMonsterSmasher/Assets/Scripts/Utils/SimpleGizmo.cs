using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SimpleGizmo : MonoBehaviour {
	
	public delegate void PlayAreaEvent( int _level, Vector3 pos, float radius );
	public static event PlayAreaEvent onAddPlayArea;
	
	public Color GizmoColor;
	public float Radius;
	public bool LOOKAT = false;
	public Transform LookTarget;
	
	public bool GameArea = false;
	public SphereCollider Sphere;
	
	public int LEVEL = 1;
	
	
	
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(LOOKAT)
		{
			
			transform.LookAt(LookTarget.position);	
		}
		
		if(GameArea)
		{
			if(Sphere != null)
			{
				Sphere.radius = Radius;	
			}
		}
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = GizmoColor;
        Gizmos.DrawWireSphere(transform.position, Radius);
	}
}
