using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CircleMaker : MonoBehaviour
{
	float frequency = 1.0f;
	float amplitudeMin = 0.08f;
	float amplitudeMax = 0.12f;
	float feather = 0.1f;
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

	void OnCollisionEnter(Collision col)
	{
		oldMaterial = material;
		room = col.collider.gameObject;
		material = room.GetComponent<Renderer>().material;

		oldMaterial.SetFloat("_Radius", 0);
		oldMaterial.SetFloat("_InnerRadius", 0);
		oldMaterial.SetFloat("_OuterRadius", 0);
	}

	Vector2 LocationInRoom()
	{
		foreach(Transform child in room.transform)
		{
			if(child.tag == "BottomLeft")
			{
				currentBottomLeft = child;
			}
		}
		float x = (transform.position.x - currentBottomLeft.position.x) / (10);
		float y = (transform.position.y - currentBottomLeft.position.y) / (10);
		return new Vector2(x, y);
	}
}