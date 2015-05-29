﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	[SerializeField]
	private GameObject hazard;

	[SerializeField]
	private Vector3 spawnValues;

	[SerializeField]
	private int hazardCount;

	[SerializeField]
	private float spawnWait;

	[SerializeField]
	private float startWait;

	[SerializeField]
	private float waveWait;

	void Start()
	{
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while(true)
		{
			for (int i=0; i<hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
		}
		yield return new WaitForSeconds(waveWait);
	}
}
