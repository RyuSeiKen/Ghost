using UnityEngine;
using System.Collections;

public class Simple2DMoveController : MonoBehaviour {

	public KeyCode Left = KeyCode.LeftArrow;
	public KeyCode Right = KeyCode.RightArrow;
	public KeyCode Up = KeyCode.UpArrow;
	public KeyCode Down = KeyCode.DownArrow;
	Vector3 faceDown = new Vector3(0, 0, 0);
	Vector3 faceRight = new Vector3(0, 0, 90);
	Vector3 faceUp = new Vector3(0, 0, 180);
	Vector3 faceLeft = new Vector3(0, 0, 270);
	public float speed;

	void Update () 
	{
    Vector3 pos = transform.localPosition;
	
    if(Input.GetKey(Left))
	{
			pos -= transform.up * speed * Time.deltaTime;
		transform.eulerAngles = faceLeft;
	}

    else if(Input.GetKey(Right)) 
	{
			pos -= transform.up * speed * Time.deltaTime;
		transform.eulerAngles = faceRight;
	}

	else if(Input.GetKey(Up)) 
	{
			pos -= transform.up * speed * Time.deltaTime;
		transform.eulerAngles = faceUp;
	}

	else if(Input.GetKey(Down)) 
	{
		pos -= transform.up * speed * Time.deltaTime;
		transform.eulerAngles = faceDown;
	}

    transform.localPosition = pos;
	}
}
