using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AttackScript : MonoBehaviour {

	public bool attackmode;
	public bool ball_now;
	public GameObject player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		ball_now = false;

	}
	public void Shot(GameObject ball){
		Rigidbody ball_rb = ball.GetComponent<Rigidbody> ();
		if (attackmode) {
			Vector3 v = (ball.transform.position - transform.position).normalized;
			ball_rb.linearVelocity = v * 9.0f;
		}
	}
	public void Touch(){
		if (SceneManager.GetActiveScene().name != "Easy_1" && SceneManager.GetActiveScene().name != "Easy_1_4") {
			player.SendMessage ("PushAttack");
		}
	}
}
