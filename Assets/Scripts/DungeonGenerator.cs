using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonGenerator : MonoBehaviour {

	public GameObject _StartRoom;


	GameObject GameManager;
	GridManager Grid;
	RoomManager RoomLists;
	GameObject ChosenRoom;
	FillRoom fill;
	Joueur playerScript;
	GameObject _Player;


	int NewRoomXpos;
	int NewRoomYpos;

	List<GameObject> NewRooms = new List<GameObject>();
	List<GameObject> InstantiateRooms = new List<GameObject>();
	List<GameObject> Temp = new List<GameObject> ();

	int maxGeneration;

	// Use this for initialization
	void Start () {

		maxGeneration = 0;

		_Player = GameObject.FindGameObjectWithTag ("Player");
		playerScript = _Player.GetComponent<Joueur> ();
		GameManager = GameObject.FindGameObjectWithTag ("Manager");
		Grid = GameManager.GetComponent<GridManager> ();
		RoomLists = GameManager.GetComponent<RoomManager> ();
		fill = GameManager.GetComponent<FillRoom> ();

		GameObject NewRoom = Instantiate (_StartRoom) as GameObject;

		Grid._Dungeon [11, 11] = NewRoom;

		Room RoomProperties = NewRoom.GetComponent<Room> ();
		RoomProperties.Xpos = 11;
		RoomProperties.Ypos = 11;

		NewRooms.Add (NewRoom);

		for (int f = 0; f < 7; f++) {
			
			ShuffleList ();
			Generation ();
			maxGeneration++;
		}

		fill.Fill ();

	}

	void Generation() 
	{
		foreach (GameObject _NewRoom in NewRooms) 
		{
			GameObject ActiveRoom = _NewRoom;
			RoomGenerator(ActiveRoom);
		}

		ListeTransfert ();
	}

	void RoomGenerator(GameObject _UseRoom) 
	{
		
		Room RoomProperties = _UseRoom.GetComponent<Room> ();

		if (RoomProperties._upAvailable == true) 
		{
			CreateRoom (1, _UseRoom);
		}

		if (RoomProperties._downAvailable == true) 
		{
			CreateRoom (2, _UseRoom);
		}

		if (RoomProperties._leftAvailable == true) 
		{
			CreateRoom (3, _UseRoom);
		}

		if (RoomProperties._rightAvailable == true) 
		{
			CreateRoom (4, _UseRoom);
		}


	}

	void CreateRoom(int side, GameObject CurrentRoom)
	{
		
		Room CurrentRoomProperties = CurrentRoom.GetComponent<Room> ();
		int CurrentRoomX = CurrentRoomProperties.Xpos;
		int CurrentRoomY = CurrentRoomProperties.Ypos;
		CheckRooms (side, CurrentRoomProperties.Xpos, CurrentRoomProperties.Ypos);

		switch(side) 
		{
		case 1:
			if (Grid._Dungeon [CurrentRoomX, CurrentRoomY + 1] == null) 
			{
				GameObject NextRoomUp = Instantiate (ChosenRoom) as GameObject;
			
				InstantiateRooms.Add (NextRoomUp);

				Grid._Dungeon [CurrentRoomX, CurrentRoomY + 1] = NextRoomUp;


				Room NextRoomUpProperties = NextRoomUp.GetComponent<Room> ();
				NextRoomUpProperties._downAvailable = false;
				NextRoomUpProperties.Xpos = CurrentRoomX;
				NextRoomUpProperties.Ypos = CurrentRoomY + 1;

				NextRoomUp.transform.position = CurrentRoom.transform.position + new Vector3 (0, 10, 0);
			} else {}

			break;

		case 2:
			if (Grid._Dungeon [CurrentRoomX, CurrentRoomY - 1] == null) {
				GameObject NextRoomDown = Instantiate (ChosenRoom) as GameObject;

				InstantiateRooms.Add (NextRoomDown);

				Grid._Dungeon [CurrentRoomX, CurrentRoomY - 1] = NextRoomDown;

				Room NextRoomDownProperties = NextRoomDown.GetComponent<Room> ();
				NextRoomDownProperties._upAvailable = false;
				NextRoomDownProperties.Xpos = CurrentRoomX;
				NextRoomDownProperties.Ypos = CurrentRoomY - 1;

				NextRoomDown.transform.position = CurrentRoom.transform.position + new Vector3 (0, -10, 0);
			} else {}
				
			break;

		case 3:
			if (Grid._Dungeon [CurrentRoomX - 1, CurrentRoomY] == null) {				
				GameObject NextRoomLeft = Instantiate (ChosenRoom) as GameObject;

				InstantiateRooms.Add (NextRoomLeft);

				Grid._Dungeon [CurrentRoomX - 1, CurrentRoomY] = NextRoomLeft;

				Room NextRoomLeftProperties = NextRoomLeft.GetComponent<Room> ();
				NextRoomLeftProperties._rightAvailable = false;
				NextRoomLeftProperties.Xpos = CurrentRoomX - 1;
				NextRoomLeftProperties.Ypos = CurrentRoomY;

				NextRoomLeft.transform.position = CurrentRoom.transform.position + new Vector3 (-10, 0, 0);
			} else {}

			break;

		case 4:
			if (Grid._Dungeon [CurrentRoomX + 1, CurrentRoomY] == null) {
				GameObject NextRoomRight = Instantiate (ChosenRoom) as GameObject;

				InstantiateRooms.Add (NextRoomRight);
				Grid._Dungeon [CurrentRoomX + 1, CurrentRoomY] = NextRoomRight;

				Room NextRoomRightProperties = NextRoomRight.GetComponent<Room> ();
				NextRoomRightProperties._leftAvailable = false;
				NextRoomRightProperties.Xpos = CurrentRoomX + 1;
				NextRoomRightProperties.Ypos = CurrentRoomY;

				NextRoomRight.transform.position = CurrentRoom.transform.position + new Vector3 (10, 0, 0);
			} else {}

			break;
		}

	}

	void ListeTransfert() 
	{
		NewRooms.Clear ();
		foreach (GameObject Rooms in InstantiateRooms) 
		{
			NewRooms.Add (Rooms);
		}
		InstantiateRooms.Clear ();
	}

	void CheckRooms(int side, int RoomCheckedXpos, int RoomCheckedYpos) 
	{	
		
		int _up;
		int _down;
		int _left;
		int _right;



		switch(side)
		{
		case 1: 
			NewRoomXpos = RoomCheckedXpos;
			NewRoomYpos = RoomCheckedYpos + 1;

			break;

		case 2:
			NewRoomXpos = RoomCheckedXpos;
			NewRoomYpos = RoomCheckedYpos - 1;

			break;

		case 3:
			NewRoomXpos = RoomCheckedXpos - 1;
			NewRoomYpos = RoomCheckedYpos;

			break;

		case 4:
			NewRoomXpos = RoomCheckedXpos + 1;
			NewRoomYpos = RoomCheckedYpos;

			break;


		}

		if (Grid._Dungeon [NewRoomXpos, NewRoomYpos + 1] != null) {

			Room UpRoomProperties = Grid._Dungeon [NewRoomXpos, NewRoomYpos + 1].GetComponent<Room> ();
			if (UpRoomProperties._down == true) {
				
				_up = 1;
			} else {
				_up = 0;
			}


		} else {
			if (maxGeneration == 6) {
				_up = 0;
			} else {
				_up = 2;
			}
		}


			if (Grid._Dungeon [NewRoomXpos, NewRoomYpos - 1] != null) {

				Room DownRoomProperties = Grid._Dungeon [NewRoomXpos, NewRoomYpos - 1].GetComponent<Room> ();
				if (DownRoomProperties._up == true) {
				
					_down = 1;

				} else {
					_down = 0;
				}


			} else {
				if (maxGeneration == 6) {
					_down = 0;
				} else {
					_down = 2;
				}
			}

		if (Grid._Dungeon [NewRoomXpos - 1, NewRoomYpos] != null) {

			Room LeftRoomProperties = Grid._Dungeon [NewRoomXpos - 1, NewRoomYpos].GetComponent<Room> ();
			if (LeftRoomProperties._right == true) {

				_left = 1;
			} else {
				_left = 0;
			}


		} else {
			if (maxGeneration == 6) {
				_left = 0;
			} else {
				_left = 2;
			}
		}

		if (Grid._Dungeon [NewRoomXpos + 1, NewRoomYpos] != null) {
			
			Room RightRoomProperties = Grid._Dungeon [NewRoomXpos + 1, NewRoomYpos].GetComponent<Room> ();

			if (RightRoomProperties._left == true) {

				_right = 1;
			} else {
				_right = 0;
			}


		} else {
			if (maxGeneration == 6) {
				_right = 0;
			} else {
				_right = 2;
			}
		}

		//Debug.Log (_up +""+ _down +""+ _left +""+ _right);
		CheckArround (_up, _down, _left, _right);



	}

	void CheckArround (int up, int down, int left, int right)
	{
		
		bool UpCheck = false;
		bool DownCheck = false;
		bool LeftCheck = false;
		bool RightCheck = false;
		bool AllCheck = false;


		while (AllCheck == false) {

			bool enterUp = false;
			bool enterDown = false;
			bool enterLeft = false;
			bool enterRight = false;
			
			UpCheck = false;
			DownCheck = false;
			LeftCheck = false;
			RightCheck = false;
			
			int randomRoom = Random.Range (0, 15);
			ChosenRoom = RoomLists._AllRooms [randomRoom];

			foreach (GameObject ChoseUp in RoomLists._upRooms) {
			
				if (ChosenRoom == ChoseUp) {

					if (up == 0) {
						enterUp = true;
						UpCheck = false;
					} else {
						UpCheck = true;
					}
									
				}
			}
			

			if (UpCheck == false ) {

				if (up == 0 && enterUp == false) {
					UpCheck = true;
				}

				if (up == 2) {
					UpCheck = true;
				}

			}
			foreach (GameObject ChoseDown in RoomLists._downRooms) {

				if (ChosenRoom == ChoseDown) {

					if (down == 0) {
						enterDown = true;
						DownCheck = false;
					} else {
						DownCheck = true;
					}
										
				}
			}



			if (DownCheck == false ) {

				if (down == 0 && enterDown == false) {
					DownCheck = true;
				}

				if (down == 2) {
					DownCheck = true;
				}

			}
			foreach (GameObject ChoseLeft in RoomLists._leftRooms) {

				if (ChosenRoom == ChoseLeft) {

					if (left == 0) {
						enterLeft = true;
						LeftCheck = false;
					} else {
						LeftCheck = true;
					}
		
				}
			}


			if (LeftCheck == false ) {

				if (left == 0 && enterLeft == false) {
					LeftCheck = true;
				}

				if (left == 2) {
					LeftCheck = true;
				}

			}
			foreach (GameObject ChoseRight in RoomLists._rightRooms) {

				if (ChosenRoom == ChoseRight) {
					

					if (right == 0) {
						
						enterRight = true;
						RightCheck = false;
					} else {
						
						RightCheck = true;
					}
											
				}
			}


			if (RightCheck == false ) {
				
					if (right == 0 && enterRight == false) {
						RightCheck = true;
					}

					if (right == 2) {
						RightCheck = true;
					}

			}
		
			if (UpCheck == true && RightCheck == true && DownCheck == true && LeftCheck == true) 
			{
				AllCheck = true;
			}

		}

		AllCheck = false;
	}

	void ShuffleList(){

		for (int i = 0; i < 15; i++) 
			
		{
			GameObject shuffledRoom = RoomLists._AllRooms [i];
			RoomLists._AllRooms.RemoveAt(i);
			RoomLists._AllRooms.Add (shuffledRoom);
			
		}


	}

	// Update is called once per frame
	public void NextLevel () 
	{
		playerScript.ResetPos ();
		maxGeneration = 0;
		GameObject NewRoom2 = Instantiate (_StartRoom) as GameObject;

		Grid._Dungeon [11, 11] = NewRoom2;

		Room RoomProperties = NewRoom2.GetComponent<Room> ();
		RoomProperties.Xpos = 11;
		RoomProperties.Ypos = 11;

		NewRoom2.transform.position = new Vector3 (_Player.transform.position.x, _Player.transform.position.y, 0);;

		NewRooms.Add (NewRoom2);

		for (int h= 0; h < 7; h++) {
			
			ShuffleList ();
			Generation ();
			maxGeneration++;
		}

		fill.Fill ();

	}
}
