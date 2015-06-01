using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	[SerializeField]
	private GameObject explosion;

	[SerializeField]
	private GameObject playerExplosion;

	[SerializeField]
	private int scoreValue;

	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Boundary") 
		{
			explode(other);
			gameController.AddScore(scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

	private void explode(Collider other)
	{
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") 
		{
			Instantiate(playerExplosion, transform.position, transform.rotation);
			gameController.GameOver();
		}
	}
}
