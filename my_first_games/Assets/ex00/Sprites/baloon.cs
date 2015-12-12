using UnityEngine;
using System.Collections;

public class baloon : MonoBehaviour {

	public float 	blow;
	public int 		wait;
	private float 	timer;
	private int 	loose;

	// Update is called once per frame

	void Update () 
	{

		timer += Time.deltaTime;
		if (transform.localScale.x > 0.5 && transform.localScale.x < 7) 
		{
			if (Input.GetKeyDown ("space") && wait == 0) 
			{
				transform.localScale += new Vector3 (0.3F, 0.3F, 0);
				blow += 10;
				if(blow > 30)
				{
					blow = 0;
					wait = 120;
				}
			} 
			else 
			{
				transform.localScale += new Vector3 (-0.02F, -0.02F, 0);
				blow -= 1;
				wait -= 1;
				if(blow < 0)
				{
					blow = 0;
				}
				if(wait < 0)
				{
					wait = 0;
				}
			}
		}
		else if (loose == 0)
		{
			loose = 1;
			timer = Mathf.RoundToInt(timer);
			Debug.Log ("Balloon life time: " + timer+"s");
			GameObject.Destroy(gameObject);
		}

	}
}
