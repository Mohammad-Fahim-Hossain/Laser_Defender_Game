using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pojectile : MonoBehaviour {
	public float fire=75f;

	public float GetFire(){
		return fire;
	}
	public void LeserDes(){
		Destroy (gameObject);
	
	}


}
