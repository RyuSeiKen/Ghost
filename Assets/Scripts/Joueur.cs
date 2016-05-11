using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Joueur : MonoBehaviour {

	public Text Level;
	public float level;


	void Start() {
		level = 1f;
		UpdateLevelText ();



	}

	// Use this for initialization
	public void ResetPos () {

		level = level + 0.5f;
		UpdateLevelText();



	}

	public void UpdateLevelText() {

		Level.text = "Level " + level;



	}
	// Update is called once per frame
}
