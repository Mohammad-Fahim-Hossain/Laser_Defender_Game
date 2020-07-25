using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


	public void LevelManage(string Level){
		
		Application.LoadLevel (Level);

	}
	public void Quit(){
		Application.Quit ();
	}
	public void NextLevel(){

		Application.LoadLevel (Application.loadedLevel + 1);
	}




}
