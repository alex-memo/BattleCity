using System.Collections;
using UnityEngine;

public class GameManager : InstanceFactory<GameManager>
{
	public GameObject Player { get; set; }

	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject[] enemySpawners;
	[SerializeField] private float spawnRate = 10f;

	public int score = 0;
	public OnScoreChange OnScoreChange;
	public OnPlayerDeath OnPlayerDeath;

	protected override void Awake()
	{
		base.Awake();

		OnScoreChange += AddScore;
	}

	private void Start()
	{
		StartCoroutine(spawnEnemiesCoroutine());
	}
	private IEnumerator spawnEnemiesCoroutine()
	{
		while (true)
		{
			SpawnEnemies();
			yield return new WaitForSeconds(spawnRate);
		}
	}

	private void SpawnEnemies()
	{
		foreach (GameObject enemySpawner in enemySpawners)
		{
			Instantiate(enemyPrefab, enemySpawner.transform.position, Quaternion.identity, null);
		}
	}

	private void AddScore(int scoreToAdd)
	{
		score += scoreToAdd;
	}
}
public delegate void OnScoreChange(int score);
public delegate void OnPlayerDeath();