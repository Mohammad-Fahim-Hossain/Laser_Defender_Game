using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLevel : MonoBehaviour {

	private LevelManager levelmanager; 

	public void OnTriggerEnter2D(Collider2D trigger){
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
		levelmanager.LevelManage ("Lose");
	
	}
}
