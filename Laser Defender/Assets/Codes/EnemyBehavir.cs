using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavir : MonoBehaviour {
	private float Health=150f;
	public GameObject enemyleser;
	float LeserSpeed=7f;
	float FireEnemyPerSec=0.5f;
	int Point=150;
	private Score Score;
	public AudioClip FireSound;
	public AudioClip DieSound;



	void Start(){
		Score = GameObject.Find ("Score").GetComponent<Score> ();
	
	}

	void Update(){
		float probality = Time.deltaTime * FireEnemyPerSec;
		if (Random.value < probality) {
			Fire ();
		}
	
	
	}
	void Fire(){
		
		GameObject LeserBean = Instantiate (enemyleser,transform.position, Quaternion.identity) as GameObject;
		LeserBean.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -LeserSpeed, 0);
		AudioSource.PlayClipAtPoint (FireSound, transform.position);

	}

	 void OnTriggerEnter2D(Collider2D collision){
	
		Pojectile life=collision.gameObject.GetComponent<Pojectile> ();
		if (life) {
			Health -= life.GetFire ();
			life.LeserDes ();
			if (Health <= 0) {
				Destroy (gameObject);
				Score.ScorePoint (Point);
				AudioSource.PlayClipAtPoint (DieSound, transform.position);
			}
		}
	
	}

		






}
