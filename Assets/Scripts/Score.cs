using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {
	public static int[] point;
	public Text[] scorelabel;
	public static bool GAME;
	public static int PLAYERCOUNT;

	public static int MaxScore = 10;
	// Use this for initialization
	void Start () {
		GAME = true;
		point = new int[4];
		for (int i = 0; i < 4; i++) {
			point [i] = 0;
		}
		PLAYERCOUNT = scorelabel.Length;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GAME) {
			for (int i = 0; i < scorelabel.Length; i++) {
				scorelabel [i].text = "HP:" + (MaxScore - point [i]).ToString ();
			}
			if (scorelabel.Length == 4) {
				if ((point [0] == MaxScore) || (point [1] == MaxScore && point [2] == MaxScore && point [3] == MaxScore)) {
					GAME = false;
				}
			} else if (scorelabel.Length == 2) {
				if ((point [0] == MaxScore) || (point [1] == MaxScore)) {
					GAME = false;
				}
			}
		}
	
	}
}
