using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

	public bool _left; 
	public bool _right;
	public bool _up;
	public bool _down;

	//[HideInInspector]
	public bool _leftAvailable, _rightAvailable, _upAvailable, _downAvailable;


	public int Xpos, Ypos;

	void Awake ()
	{
		if (_left == true)
			_leftAvailable = true;

		if (_right == true)
			_rightAvailable = true;

		if (_up == true)
			_upAvailable = true;

		if (_down == true)
			_downAvailable = true;



	}
}
