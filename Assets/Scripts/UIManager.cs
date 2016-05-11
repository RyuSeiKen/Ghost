using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public Text time;
	[HideInInspector]
	public int a = 0;
	[HideInInspector]
	public int b = 0;

	void Update () 
	{
		a = (int)Time.time;
		b = a / 60;

		if(a%60 < 10)
		{
			time.text = b + ":0" + a%60;
		}
		else
		{
			time.text = b + ":" + a%60;
		}
	}
}
