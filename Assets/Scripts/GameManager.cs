using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject[] player;
	public GameObject[] Kabe;
	public Transform[] points;

	public GameObject panel;
	public GameObject panel2;
	Image image;
	//Renderer rd;
	float timer;
	float alltimer;
	float speed = 5;
	GameObject ball;
	GameObject bom;

	// Use this for initialization
	void Start () {
		timer = 0;
		alltimer = 0;
		ball = Resources.Load ("Ball") as GameObject;
		image = panel.GetComponent<Image> ();
		bom = Resources.Load ("Bom") as GameObject;
		//rd = panel.GetComponent<Renderer>();
		//InvokeRepeating ("Generate", 0, 5);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		alltimer += Time.deltaTime;
		if (timer > 3) {
			Generate ();
			timer = 0;
			if (alltimer > 30) {
				timer = 1.5f;
			}
		}
		if (Score.GAME) {
			panel.SetActive (false);
			panel2.SetActive (false);
		}else {
			if (Score.point [0] == Score.MaxScore) {
				panel2.SetActive (true);
			}
			panel.SetActive (true);
		}
		for (int i = 0; i < Score.PLAYERCOUNT; i++) {
			if (Score.point [i] == Score.MaxScore) {
				Kabe [i].SetActive (true);
				if (player [i] != null) {
					Instantiate (bom, player [i].transform.position, Quaternion.identity);
					player [i].transform.position = new Vector3 (1000,1000,1000);
		
				}
			} else {
				if (Kabe [i] != null) {
					Kabe [i].SetActive (false);
				}
			}
		}
	}

	void Generate(){
		if (Score.GAME) {
			int index = Random.Range (0, points.Length);
			float angle = Random.Range (30.0f, 60.0f);



			GameObject obj = Instantiate (ball, points [index].position, transform.rotation)as GameObject;
			Rigidbody ball_rb = obj.GetComponent<Rigidbody> ();
			float rotation = 0;
			switch (index) {
			case 0:
				rotation = 270 + angle;
				rotation = rotation * Mathf.PI / 180;
				ball_rb.velocity = new Vector3 (Mathf.Cos (rotation), 0, Mathf.Sin (rotation)) * speed;
				break;
			case 1:
				rotation = 180 + angle;
				rotation = rotation * Mathf.PI / 180;
				ball_rb.velocity = new Vector3 (Mathf.Cos (rotation), 0, Mathf.Sin (rotation)) * speed;
				break;
			case 2:
				rotation = 0 + angle;
				rotation = rotation * Mathf.PI / 180;
				ball_rb.velocity = new Vector3 (Mathf.Cos (rotation), 0, Mathf.Sin (rotation)) * speed;
				break;
			case 3:
				rotation = 90 + angle;
				rotation = rotation * Mathf.PI / 180;
				ball_rb.velocity = new Vector3 (Mathf.Cos (rotation), 0, Mathf.Sin (rotation)) * speed;
				break;
			
			
		
			default:
				break;
			}
		}


	}
	public void ReStart(){
		Application.LoadLevel (Application.loadedLevelName);
	}
	public void ToStart(){
		Application.LoadLevel ("Start");
	}
}
