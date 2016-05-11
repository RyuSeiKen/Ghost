using UnityEngine;

public class CircleMaker : MonoBehaviour
{
	float frequency = 1.0f;
	float amplitudeMin = 0.015f;
	float amplitudeMax = 0.015f;
	float feather = 0f;
	public GameObject room1;
	GameObject room;
	Material material;
	Material oldMaterial;
	Transform currentBottomLeft;

	void Start()
	{
		material = room1.GetComponent<Renderer>().material;
	}

	void Update ()
	{
		float amplitudeCenter = (amplitudeMax + amplitudeMin) * 0.5f;
		float amplitudeDeviation = (amplitudeMax - amplitudeMin) * 0.5f;
		float radius = Mathf.Sin(2.0f * Mathf.PI * frequency * Time.time) * amplitudeDeviation + amplitudeCenter;

		material.SetFloat("_Radius", radius); // just in case you want to use it
		material.SetFloat("_InnerRadius", radius - feather * 0.5f);
		material.SetFloat("_OuterRadius", radius + feather * 0.5f);
		material.SetFloat("_OffsetX", LocationInRoom().x);
		material.SetFloat("_OffsetY", LocationInRoom().y);
	}

	Vector2 LocationInRoom()
	{
		foreach(Transform child in room1.transform)
		{
			if(child.tag == "BottomLeft")
			{
				currentBottomLeft = child;
			}
		}
		float x = (transform.position.x - currentBottomLeft.position.x) / (150);
		float y = (transform.position.y - currentBottomLeft.position.y) / (150);
		return new Vector2(x, y);
	}
}