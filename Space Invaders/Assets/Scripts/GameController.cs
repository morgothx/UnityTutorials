using UnityEngine;
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

	[SerializeField]
	private GUIText scoreText;

	private int score;

	void Start()
	{
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
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
			yield return new WaitForSeconds(waveWait);
		}
	}

	private void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
}
