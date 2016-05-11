using UnityEngine;
using System.Collections;


public class End : MonoBehaviour {


	GameObject GameManager;
	GridManager Grid;
	DungeonGenerator Donjon;


	// Use this for initialization
	void OnTriggerEnter () {


		GameManager = GameObject.FindGameObjectWithTag ("Manager");
		Grid = GameManager.GetComponent<GridManager> ();
		Donjon = GameManager.GetComponent<DungeonGenerator> ();


		foreach (GameObject room in Grid._Dungeon) {

			Destroy (room);
			
		}

		GameObject[] endroom = GameObject.FindGameObjectsWithTag ("End");

		foreach (GameObject item in endroom) {

			if (item == gameObject) {
			} else {
				Destroy (item);
			}
		}

		GameObject[] coins = GameObject.FindGameObjectsWithTag ("Coin");

		foreach (GameObject coin in coins) {

			Destroy (coin);
		}

	

		Donjon.NextLevel ();




		Destroy (gameObject);


	}
	

}
