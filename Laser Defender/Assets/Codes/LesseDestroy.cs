using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesseDestroy : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D coll){
		Destroy (coll.gameObject);
	}
}
