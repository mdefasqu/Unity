using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {

	public float speed = 2F;

	public  Vector3 target;
	private Animator animator;
	
	int get_angle(Vector3 relatif)
	{
		if ((relatif.x < 1F && relatif.x > -1F) && relatif.y > 0.0F) {
			return 0;
		} else if ((relatif.x < 1F && relatif.x > -1F) && relatif.y < 0.0F) {
			return 180;
		} else if ((relatif.y < 1F && relatif.y > -1F) && relatif.x > 0.0F) {
			return 90;
		} else if (relatif.y < 1F && relatif.y > -1F && relatif.x < -0.0F) {
			return 270;
		} else if (relatif.y > 1 && relatif.x > 1) {
			return 45;
		} else if (relatif.y < -1 && relatif.x > 1) {
			return 135;
		} else if (relatif.y < -1 && relatif.x < -1) {
			return 225;
		}else if (relatif.y > 1 && relatif.x < -1) {
			return 315;
		}
		return -1;
	}

	void OnMouseDown(){
		Debug.Log (gameObject.transform.position);
	}

	void animate_character(Vector3 futur, Vector3 current)
	{
		Vector3 relatif;
		
		relatif = futur - current;

		if (get_angle(relatif) == 0) {
			animator.SetTrigger ("walk_up");
		} else if (get_angle(relatif) == 45) {
			animator.SetTrigger ("walk_up_right");
		} else if (get_angle(relatif) == 90) {
			animator.SetTrigger ("walk_right");
		}else if (get_angle(relatif) == 135) {
			animator.SetTrigger ("walk_down_right");
		}else if (get_angle(relatif) == 180) {
			animator.SetTrigger ("walk_down");
		}else if (get_angle(relatif) == 225) {
			animator.SetTrigger ("walk_down_left");
		}else if (get_angle(relatif) == 270) {
			animator.SetTrigger ("walk_left");
		}else if (get_angle(relatif) == 315) {
			animator.SetTrigger ("walk_up_left");
		}
	}

	public void move_to(Vector3 wantedPos)
	{
		this.target = wantedPos;
		target.z = 0f;
	}

	void Awake()
	{
		animator = GetComponent<Animator> ();
	}

	void Start () {
		this.target = transform.position;
	}

	void Update () {

		transform.position = Vector3.MoveTowards (transform.position, this.target, speed * Time.deltaTime);

		if (transform.position != target && Input.GetMouseButtonDown(0)) {
			animate_character(target, transform.position);
			GetComponent<AudioSource>().Play();
		}
		else if (transform.position == target) {
			animator.SetTrigger("wait");
		}
	}
}
