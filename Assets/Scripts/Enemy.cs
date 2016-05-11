using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public GameObject player;
	
	void Update () 
	{
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
	}
}
