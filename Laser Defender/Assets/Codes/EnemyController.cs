using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject EnemyPrefab;
	public float witdh;
	public float height;
	private float xmin;
	private float xmax;
	public float Speed=3f;
	private bool Move = true;



	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 LeftBoundary= Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 RightBoundary = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0, distance)); 
		xmin = LeftBoundary.x;
		xmax = RightBoundary.x;

		SwapUntillFill ();

	}

	

	void SwapUntillFill(){
		Transform FreePos = UntillFreePosition ();
		if (FreePos) {
			GameObject enemy = Instantiate (EnemyPrefab,FreePos.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = FreePos;
		}
		if (UntillFreePosition()) {
			Invoke ("SwapUntillFill", 0.2f);
		}
	
	}


			
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3 (witdh, height));
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Move) {
			transform.position += new Vector3 (Speed * Time.deltaTime, 0, 0);	
		} else {
			transform.position += new Vector3 (-Speed * Time.deltaTime, 0, 0);	
		}
	
		float RightBoundaryLine = transform.position.x + (0.5f * witdh);	
		float LeftBoundaryLine = transform.position.x - (0.5f * witdh);	
		if (LeftBoundaryLine < xmin) {
			Move = true;
		} else if (RightBoundaryLine > xmax) {
			Move = false;
		}
		if (AllMembersDead ()) {
			SwapUntillFill ();
		}
	}

	Transform UntillFreePosition(){
		foreach (Transform ChidPositionGame in transform) {
			if (ChidPositionGame.childCount == 0) {
				return ChidPositionGame;

			}	
		}
		return null;
	
	
	}	

	bool AllMembersDead(){
		foreach (Transform ChidPositionGame in transform) {
			if (ChidPositionGame.childCount > 0) {
				return false;	
			
			}	
		}
		return true;
	}


}
