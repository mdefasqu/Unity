using UnityEngine;
using System.Collections;

public class PongBall : MonoBehaviour {

	public GameObject joueur_source;

	private Player joueur = new Player();
	private GameObject joueur1;
	private GameObject joueur2;
	private float dir_y;
	private float dir_x;
	private int score_joueur1;
	private int score_joueur2;

	int 	move_ball (GameObject joueur1, GameObject joueur2)
	{
		float rand;

		rand = Random.Range (1F, 3F);
		if (transform.position.y >= 4.7F) {
			this.dir_y = -rand;
		}
		if (transform.position.y <= -4.7F) {
			this.dir_y = rand;
		}
		if ((transform.position.x >= 4.80F && transform.position.x <= 5.2F) && (transform.position.y <= joueur2.transform.position.y + 1.20F && transform.position.y >= joueur2.transform.position.y - 1.20 )) {
			this.dir_x = -1;
		}
		if ((transform.position.x <= -4.80F && transform.position.x >= -5.2F) && (transform.position.y <= joueur1.transform.position.y + 1.20F && transform.position.y >= joueur1.transform.position.y - 1.20 )) {
			this.dir_x = 1;
		}
		if(transform.position.x >= 10F || transform.position.x <= -10){
			if(transform.position.x >= 10){
				transform.Translate(-10F, -transform.position.y, 0);
				this.score_joueur1 += 1;
			} else {
				transform.Translate(10F, -transform.position.y, 0);
				this.score_joueur2 += 1;
			}
			Debug.Log("Player 1: "+this.score_joueur1+" | Player 2: "+score_joueur2);
		}
		transform.Translate (0.1F * dir_x, 0.1F * dir_y, 0);
		return 0;
	}

	// Use this for initialization
	void Start () {
		this.dir_y = 1;
		this.dir_x = -1;
		this.score_joueur1 = 0;
		this.score_joueur2 = -1;
		this.joueur1 = Instantiate (joueur_source, new Vector3 (-5.5F, 0, 0), Quaternion.identity) as GameObject;
		this.joueur2 = Instantiate (joueur_source, new Vector3 (5.5F, 0, 0), Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		joueur.moveJ1(joueur1);
		joueur.moveJ2 (joueur2);
		move_ball (this.joueur1, this.joueur2);
	}
}
