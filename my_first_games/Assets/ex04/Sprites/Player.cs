using UnityEngine;
using System.Collections;

public class Player {


	public void	moveJ1(GameObject joueur)
	{
		if(joueur.transform.position.y <= 3.85F){
			if (Input.GetKey ("w")) {
				joueur.transform.Translate(0, 0.2F, 0);
			}
		}
		if (joueur.transform.position.y >= -3.72F) {
			if (Input.GetKey ("s")) {
				joueur.transform.Translate (0, -0.2F, 0);
			}
		}
	}

	public void	moveJ2(GameObject joueur)
	{
		if (joueur.transform.position.y <= 3.85F) {
			if (Input.GetKey ("up")) {
				joueur.transform.Translate (0, 0.2F, 0);
			}
		}
		if (joueur.transform.position.y >= -3.72F){
			if (Input.GetKey ("down")) {
				joueur.transform.Translate (0, -0.2F, 0);
			}
		}
	}
}
