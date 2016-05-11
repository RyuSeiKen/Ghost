using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public GameObject ghost;
	Vector3 cameraPos;

	void Update () 
	{
		cameraPos = new Vector3(ghost.transform.position.x, ghost.transform.position.y, -10);
		transform.position = cameraPos;
	}
}
