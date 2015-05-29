using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Boundaries boundaries;

	[SerializeField]
	private float tilt;

	[SerializeField]
	private GameObject shot;

	[SerializeField]
	private Transform shotSpawn;

	[SerializeField]
	private float fireRate;

	private float nextFire;

	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;
		rigidbody.position = GetPositionRestriction();
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}

	private Vector3 GetPositionRestriction()
	{
		return new Vector3 (
			Mathf.Clamp(rigidbody.position.x, boundaries.xMin, boundaries.xMax),
			0.0f,
			Mathf.Clamp(rigidbody.position.z, boundaries.zMin, boundaries.zMax)
		);
	}
}

[System.Serializable]
public class Boundaries
{
	public float xMin, xMax, zMin, zMax;
}