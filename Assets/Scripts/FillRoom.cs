using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FillRoom : MonoBehaviour 
{

	GameObject GameManager;
	GridManager Grid;
	RoomManager RoomLists;
	public GameObject End;
	GameObject coinRoom;
	GameObject cibleReward;

	int ratioMax;
	int ratioX;
	int ratioY;
	int ratio;

	List<GameObject> cible = new List<GameObject>();
	List<GameObject> cibleCoins = new List<GameObject>();

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



				if (Grid._Dungeon [x, y] != null) {

					ratioX = 11 - x;
					ratioY = 11 - y;
					ratio = ratioX + ratioY;

					if (ratio < 0) {
						ratioX = x - 11;
						ratioY = y - 11;
						ratio = ratioX + ratioY;
					}

					if (ratio == ratioMax) { 
						 
						cible.Add (Grid._Dungeon [x, y]);

					} else {
						if (ratio > ratioMax) {

							ratioMax = ratio;
							cible.Clear ();
							cible.Add (Grid._Dungeon [x, y]);

						}
					}
																					
				}
			}
		}

		foreach (GameObject room in cible) {

			GameObject EndRoom = Instantiate (End) as GameObject;
			EndRoom.transform.position = room.transform.position;

		}



		for (int c = 0; c < Grid.DungeonLength; c++) {


			for (int d = 0; d < Grid.DungeonWidth; d++) {


				if (Grid._Dungeon [c, d] != null) {

					if (Grid._Dungeon [c, d] != Grid._Dungeon [11, 11]) 
					{
						cibleCoins.Add (Grid._Dungeon [c, d]);
					}
					
				
				}


			}


		}
		foreach (GameObject item in cible) {
			cibleCoins.Remove (item);
			
		}

		foreach (GameObject room in cibleCoins) {
			
		
			int _random = Random.Range (0, 10);

				switch (_random) {

				case 0:
					coinRoom = Instantiate (RoomLists._coins [0]) as GameObject;
					coinRoom.transform.position = room.transform.position;
					break;
				case 1:
					coinRoom = Instantiate (RoomLists._coins [0]) as GameObject;
					coinRoom.transform.position = room.transform.position;
					break;
				case 2:
					coinRoom = Instantiate (RoomLists._coins [0]) as GameObject;
					coinRoom.transform.position = room.transform.position;
					break;

				case 3:
					coinRoom = Instantiate (RoomLists._coins [1]) as GameObject;
					coinRoom.transform.position = room.transform.position;
					break;

				case 4:
					coinRoom = Instantiate (RoomLists._coins [2]) as GameObject;
					coinRoom.transform.position = room.transform.position;
					break;

				case 5:
					coinRoom = Instantiate (RoomLists._coins [3]) as GameObject;
					coinRoom.transform.position = room.transform.position;
					break;
				case 6:
					coinRoom = Instantiate (RoomLists._coins [3]) as GameObject;
					coinRoom.transform.position = room.transform.position;
					break;
				case 7:
					coinRoom = Instantiate (RoomLists._coins [3]) as GameObject;
					coinRoom.transform.position = room.transform.position;
					break;

				case 8:
					coinRoom = Instantiate (RoomLists._coins [4]) as GameObject;
					coinRoom.transform.position = room.transform.position;
					break;

				case 9:
					coinRoom = Instantiate (RoomLists._coins [5]) as GameObject;
					coinRoom.transform.position = room.transform.position;
					break;

				default:
					break;
				}

			}

		cible.Clear ();
		cibleCoins.Clear ();

	}
<<<<<<< HEAD


=======
>>>>>>> 84a7ad38f81128664b8821b572b9df9c9c5396ae
}
	


