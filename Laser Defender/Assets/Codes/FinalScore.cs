using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Text MyText=GetComponent<Text>();
		MyText.text = Score.score.ToString ();
		Score.Reset ();
	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
