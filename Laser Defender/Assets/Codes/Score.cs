using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

	public static int score;
	private Text myText;

	// Use this for initialization
	void Start () {
		myText=GetComponent<Text>();
		Reset ();
	}
	public void ScorePoint(int point){
		
		score+=point;
		myText.text = score.ToString();

	} 
	public int RetriveScore(){
		return score;
		Reset ();
	}
	public static void Reset(){
		score = 0;
	
	}

}
