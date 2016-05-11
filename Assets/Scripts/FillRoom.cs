using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FillRoom : MonoBehaviour {

	GameObject GameManager;
	GridManager Grid;
	RoomManager RoomLists;
	public GameObject End;

	int ratioMax;
	int ratioX;
	int ratioY;
	int ratio;

	List<GameObject> cible = new List<GameObject>();

	// Use this for initialization
	public void Fill () {
		
		cible.Clear ();
		ratioMax = 0;
		ratioX = 0;
		ratioY = 0;
		ratio = 0;

		GameManager = GameObject.FindGameObjectWithTag ("Manager");
		Grid = GameManager.GetComponent<GridManager> ();
		RoomLists = GameManager.GetComponent<RoomManager> ();

		for (int x = 0; x < Grid.DungeonLength; x++) {

			for (int y = 0; y < Grid.DungeonWidth; y++) {

				if (Grid._Dungeon [x, y] != null) 
				
				{

					ratioX = 11 - x;
					ratioY = 11 - y;
					ratio = ratioX + ratioY;

					if (ratio < 0) {
						ratioX = x-11;
						ratioY = y-11;
						ratio = ratioX + ratioY;
					}

					if (ratio == ratioMax) { 
						 
						cible.Add(Grid._Dungeon[x,y]);

						} else { if (ratio > ratioMax) {

									ratioMax = ratio;
									cible.Clear();
									cible.Add(Grid._Dungeon[x,y]);

								}
						}
																					
				}
			}
		}

		foreach (GameObject room in cible) {

			GameObject EndRoom = Instantiate (End) as GameObject;
			EndRoom.transform.position = room.transform.position;
			
		}

		foreach (GameObject otherRoom in Grid._Dungeon) {

			bool reward = true;

			foreach (GameObject room in cible) {

				if (otherRoom == room) {
					reward = false;
				}
				
			}

			if (reward = true) {




			}
			
		}
			


	}
	

}
