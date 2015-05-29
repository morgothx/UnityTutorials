using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	[SerializeField]
	private GameObject hazard;

	[SerializeField]
	private Vector3 spawnValues;

	void Start()
	{
		SpawnWaves ();
	}

	void SpawnWaves()
	{
		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnPosition, spawnRotation);
	}
}
