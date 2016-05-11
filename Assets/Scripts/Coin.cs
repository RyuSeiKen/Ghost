using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	GameObject Manager;
	ScoreManager Score;
	// Use this for initialization
	void Start () {
		Manager = GameObject.FindGameObjectWithTag ("ScoreManager");
		Score = Manager.GetComponent<ScoreManager> ();

	}
	
	// Update is called once per frame
	void OnTriggerEnter () {

		Score.IncrementScore ();
		Destroy (gameObject);
	
	}
}
