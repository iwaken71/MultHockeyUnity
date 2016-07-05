using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	Rigidbody rb;
	AudioSource source;
	public AudioClip clip;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		source = GetComponent<AudioSource> ();
		source.clip = clip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider col){
		
		if (col.gameObject.tag == "Attack") {
			col.gameObject.SendMessage ("Shot",this.gameObject);
			col.gameObject.SendMessage ("Touch");
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "AI") {
			col.gameObject.SendMessage ("Add",this.gameObject);
		}if (col.gameObject.tag == "AI3") {
			col.gameObject.SendMessage ("Add",this.gameObject);
		}if (col.gameObject.tag == "AI4") {
			col.gameObject.SendMessage ("Add",this.gameObject);
		}
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.CompareTag ("AI")) {
			col.gameObject.SendMessage ("Remove",this.gameObject);
		}if (col.gameObject.tag == "AI3") {
			col.gameObject.SendMessage ("Remove",this.gameObject);
		}if (col.gameObject.tag == "AI4") {
			col.gameObject.SendMessage ("Remove",this.gameObject);
		}
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.CompareTag ("Ball")) {
			source.Play ();
		}
	}
}
