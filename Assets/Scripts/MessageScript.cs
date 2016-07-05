using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageScript : MonoBehaviour {
	public Text mes;
	public GameObject fukidashi;
	string[] aori;
	string[] fuan;
	int point = 0;
	int point2 = 0; 
	float timer = 15;


	// Use this for initialization
	void Start () {
		point = 0;
		aori = new string[6];
		mes.text = "Are you ready?";

		aori [0] = "Nice!";
		aori [1] = "OK!";
		aori [2] = "lucky!";
		aori [3] = "Super Shot!";
		aori [4] = "All right!";
		aori [5] = "Good!";
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			mes.text = "";
		} 
		if (7 < timer && timer < 12) {
			mes.text = "GO!!!";
		}
		if (fukidashi != null) {
			if (mes.text.Length == 0) {
				fukidashi.SetActive (false);
			} else {
				fukidashi.SetActive (true);
			}
		}
		if (Score.GAME) {
			if (Score.point [1] > 0) {
				if (Score.point [0] == 0) {
					mes.text = "Let's Hokey!";
					timer = 7;
				} else {
					if (Score.point [1] > 0) {
						if (point != Score.point [0]) {
							point = Score.point [0];
							mes.text = aori [Random.Range (0, aori.Length)];
							timer = 7;
						}
				
					}
					if (Score.point [0] - Score.point [1] <= -3) {
						mes.text = "help me!!!";
						timer = 7;
					}
					else if (Score.point [0] - Score.point [1] <= -2) {
						mes.text = "oh my God!!!";
						timer = 7;
					}
				}

			}
		} else {
			if (Score.point [0] == Score.MaxScore) {
				mes.text = "You Lose. Again?";
			}else if(Score.point [1] == Score.MaxScore){
				mes.text = "You Win!";
			}
		}
	
	}
}
