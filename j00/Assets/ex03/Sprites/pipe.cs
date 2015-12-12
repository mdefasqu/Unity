using UnityEngine;
using System.Collections;

public class pipe : MonoBehaviour {

	public GameObject pipe_orig;
	public GameObject bird;
	private GameObject pipe1;
	private GameObject pipe2;

	private int count1;
	private int count2;
	private int score;
	private int game_stop;
	private float speed;
	private float timer;

	float  	pipe_run(GameObject pipe)
	{
		pipe.transform.Translate (-0.1F * speed, 0, 0);
		speed += 0.001F;
		return pipe.transform.localPosition.x;
	}

	void	reset_pipe(GameObject pipe)
	{
		pipe.transform.Translate (20, 0, 0);
	}

	// Use this for initialization
	void Start () {
		this.count1 = 0;
		this.count2 = 0;
		speed = 1;
		game_stop = 0;
		pipe1 = (GameObject)GameObject.Instantiate (pipe_orig, new Vector3 (9, 0, 0), Quaternion.identity);
		pipe2 = (GameObject)GameObject.Instantiate (pipe_orig, new Vector3 (20, 0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (game_stop == 0) {
			float pos_pipe1;
			float pos_pipe2;

			timer += Time.deltaTime;
			pos_pipe1 = pipe_run (pipe1);
			pos_pipe2 = pipe_run (pipe2);


			if (pos_pipe1 < -10) {
				reset_pipe (pipe1);
				this.count1 = 0;
			}
			if (pos_pipe2 < -10) {
				reset_pipe (pipe2);
				this.count2 = 0;
			}
			if (pos_pipe1 < 0 && this.count1 == 0) {
				this.score += 5;
				count1 = 1;
			}
			if (pos_pipe1 < 0 && this.count1 == 0) {
				this.score += 5;
				count2 = 1;
			}
			if ((((pos_pipe1 <= 1 && pos_pipe1 >= -1) || (pos_pipe2 <= 1 && pos_pipe2 >= -1)) && (bird.transform.position.y >= 1.3F || bird.transform.position.y <= -1.7F))
			    || bird.transform.position.y <= -3.3F || bird.transform.position.y >= 5.15F) {
				game_stop = 1;
				//bird.GetComponent<bird> ().die ();
				Debug.Log ("Score: "+this.score+"\nTime: "+ Mathf.RoundToInt(this.timer)+"s\n");
			}
		}
	}
}
