using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public float Speed;
	float xmax;
	float xmin;
	float paddin=1f;
	public GameObject leserPrefab;
	public float LeserSpeed;
	private float Health=500f;
	public AudioClip FireSound;


	void OnTriggerEnter2D(Collider2D collision){

		Pojectile life=collision.gameObject.GetComponent<Pojectile> ();
		if (life) {
			Health -= life.GetFire ();
			life.LeserDes ();
			if (Health <= 0) {

				Die ();

			}
		}

	}
	void Die(){
		LevelManager level=GameObject.Find ("Level Manager").GetComponent<LevelManager> ();
		level.LevelManage ("Win");
		Destroy (gameObject);



	}



	void Start(){
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xmax = rightmost.x-paddin;
		xmin = leftmost.x+paddin;


	}
	void Fire(){
		Vector3 pos = transform.position + new Vector3 (0, 1f, 0);
		GameObject bean = Instantiate (leserPrefab,pos, Quaternion.identity) as GameObject ;
		bean.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, LeserSpeed, 0);
		AudioSource.PlayClipAtPoint (FireSound, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
			
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000001f, 0.2f);
		} 
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ();
		}
		 else
		if (Input.GetKey(KeyCode.RightArrow )) {
			transform.position += new Vector3 (Speed * Time.deltaTime, 0, 0);
		}
		else if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position += new Vector3 (-Speed * Time.deltaTime, 0, 0);
		}
		float newx = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newx, transform.position.y, transform.position.z);
	}
}
