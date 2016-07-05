using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScript : MonoBehaviour {
	int status = 0;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		panel.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (status > 0) {
			panel.SetActive (true);
		} else {
			panel.SetActive (false);
		}
	
	}
	public void Select(int n){
		status = n;
	}
	public void Back(){
		status = 0;
	}
	public void Push(int n){
		if (status == 1) {
			if (n == 1) {
				Application.LoadLevel ("Easy_1");
			} else if (n == 2) {
				Application.LoadLevel ("Normal_1");
			} else if (n == 3) {
				Application.LoadLevel ("Hard_1");
			}
		} else if (status == 3) {
			if (n == 1) {
				Application.LoadLevel ("Easy_1_4");
			} else if (n == 2) {
				Application.LoadLevel ("Normal_1_4");
			} else if (n == 3) {
				Application.LoadLevel ("Hard_1_4");
			}
		}
	}
}
