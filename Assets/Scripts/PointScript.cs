using UnityEngine;
using System.Collections;

public class PointScript : MonoBehaviour {
	GameObject bom;
	public int num;
	AudioSource source;
	public AudioClip clip;

	// Use this for initialization
	void Start () {
		bom = Resources.Load ("Bom") as GameObject;
		source = GetComponent<AudioSource> ();
		source.clip = clip;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.CompareTag ("Ball")) {
			if (Score.GAME) {
				if (Score.point [num] != Score.MaxScore) {
					Score.point [num]++;
				}
			}
			Destroy (col.gameObject);
			Instantiate (bom, col.gameObject.transform.position, Quaternion.identity);

			source.Play ();
		}
	}
}

