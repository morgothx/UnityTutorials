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

	[SerializeField]
	private GUIText restartText;

	[SerializeField]
	private GUIText gameOverText;

	private int score;
	private bool gameOver;
	private bool restart;

	void Start()
	{
		Initialize ();
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if (restart)
		if (Input.GetKey (KeyCode.R))
			Application.LoadLevel (Application.loadedLevel);
	}

	private void Initialize ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
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
			checkRestart();
		}
	}

	private void checkRestart()
	{
		if (gameOver) 
		{
			restartText.text = "Press 'R' for Restart";
			restart = true;
			return;
		}
	}

	private void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
