using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
	[SerializeField]
	private float tumble;

	void Start()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
