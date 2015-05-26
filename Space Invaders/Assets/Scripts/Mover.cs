using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	[SerializeField]
	private float speed;

	void Start()
	{
		rigidbody.velocity = transform.forward * speed;
	}
}
