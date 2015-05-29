using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	[SerializeField]
	private GameObject explosion;

	[SerializeField]
	private GameObject playerExplosion;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Boundary") 
		{
			explode(other);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

	private void explode(Collider other)
	{
		Instantiate(explosion, transform.position, transform.rotation);
		if(other.tag == "Player")
			Instantiate(playerExplosion, transform.position, transform.rotation);
	}
}
