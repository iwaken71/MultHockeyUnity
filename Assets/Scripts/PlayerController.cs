using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public int player_mode; // 1は手前,2は奥,3は左側,4は右側
	public bool yoko = true; //trueなら横の動き,falseなら縦の動き
	public bool isAI; //AIを使用するかどうか
	public GameObject child;
	public float speed = 5.0f;
	public bool left,right,attack;
	public bool attackmode = false;
	float timer = 0;
	AttackScript attackscript;
	public AudioClip[] clip; 
	AudioSource source;
	public GameObject color; 
	public GameObject skill;

	// Use this for initialization
	void Start () {
		attackscript = child.GetComponent<AttackScript> ();
		source = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (isAI) {
			
		}else{
			if (player_mode == 2) {
				left = Input.GetKey ("a");
				right = Input.GetKey ("d");
				attack = Input.GetKeyDown ("w");
			} else if (player_mode == 1) {
				left = Input.GetKey ("left");
				right = Input.GetKey ("right");
				attack = Input.GetKeyDown (KeyCode.Space);
			} else if (player_mode == 3) {
				left = Input.GetKey ("a");
				right = Input.GetKey ("d");
				attack = Input.GetKeyDown ("w");
			} else if (player_mode == 5) {
				float x = CrossPlatformInputManager.GetAxis ("Horizontal");
				if (x > 0.3f) {
					right = true;
					left = false;
				} else if (x < -0.3f) {
					right = false;
					left = true;
				} else {
					left = true;
					right = true;
				}
				attack = CrossPlatformInputManager.GetButtonDown ("Jump");
			}
		}
		if (yoko) {
			if (player_mode == 1 || isAI || player_mode == 5 || player_mode == 2) {
				if (left && right) {
				} else if (left) {
					transform.position += Vector3.right * -speed * Time.deltaTime;
				} else if (right) {
					transform.position += Vector3.right * speed * Time.deltaTime;
				} 
				if (transform.position.x <= 1.8f) {
					transform.position = new Vector3 (1.8f, transform.position.y, transform.position.z);
				}
				if (transform.position.x >= 8.2f) {
					transform.position = new Vector3 (8.2f, transform.position.y, transform.position.z);
				}
			}
		} else {
			if (player_mode == 3) {
				if (left && right) {
				} else if (left) {
					transform.position += Vector3.forward * speed * Time.deltaTime;
				} else if (right) {
					transform.position += Vector3.forward * -speed * Time.deltaTime;
				} 
				if (transform.position.z <= 1.8f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 1.8f);
				}
				if (transform.position.z >= 8.2f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 8.2f);
				}
			} else if (player_mode == 4) {
				if (left && right) {
				} else if (left) {
					transform.position += Vector3.forward * -speed * Time.deltaTime;
				} else if (right) {
					transform.position += Vector3.forward * speed * Time.deltaTime;
				} 
				if (transform.position.z <= 1.8f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 1.8f);
				}
				if (transform.position.z >= 8.2f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 8.2f);
				}
			}
			
		}

		if (attack && timer <= 0) {
			source.clip = clip[1];
			source.Play ();
			attackmode = true;
			attack = false;
			timer = 5.0f;
		} 
		if (timer >= 0) {
			timer -= Time.deltaTime;
		}
		if (attackmode) {
			if (timer <= 0) {
				attackmode = false;
			}
		}
		if (timer > 4.5f && timer <= 5) {
			skill.SetActive (true);
			attackscript.attackmode = true;
		} else {
			skill.SetActive (false);
			attackscript.attackmode = false;
		}
		color.SetActive ((timer <= 0));
		attack = false;





	}
	void FixedUpdate(){
		if (player_mode == 1) {


		}
	}

	void AIMove(){
	}

	public void PushAttack(){
		if (isAI) {
			attack = true;
		}
	}
	public void NoAttack(){
		if (isAI) {
			attack = false;

		}
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ball") {
			source.clip = clip[0];
			source.Play ();
		}
	}
}
