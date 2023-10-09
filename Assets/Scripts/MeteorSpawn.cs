using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorSpawn : MonoBehaviour
{
	public GameObject[] meteorPrefab;

	public float maxSpeed = 15f;
	public float minSpawnDelay = 1f;
	public float maxSpawnDelay = 3f;
	public float spawnXLimit = 6f;
	public static float speed;
	public float startSpeed = -2;

	public float step = 0.2f;
	private bool spawnStopped;
	private GameManager gameManager;

	void Start()
	{
		speed = startSpeed;
		Spawn();
		gameManager = GameObject.FindObjectOfType<GameManager>();
		gameManager.Stop += StopSpawn;
		gameManager.SpeedUp += SpeedUp;
	}

	private void OnDestroy()
	{
		gameManager.Stop -= StopSpawn;
		gameManager.SpeedUp -= SpeedUp;
	}

	private void SpeedUp()
	{
		maxSpawnDelay -= step;
		if (speed > maxSpeed) speed = maxSpeed;
	}

	private void StopSpawn()
	{
		spawnStopped = true;
	}

	void Spawn()
	{
		if (spawnStopped) return;
		if (maxSpawnDelay <= minSpawnDelay) maxSpawnDelay = minSpawnDelay;
		float random = Random.Range(-spawnXLimit, spawnXLimit);

		Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
		
		Instantiate(SelectRandMeteor(), spawnPos, Quaternion.identity);
		Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay - step));
	}

	private GameObject SelectRandMeteor()
	{
		var index = Random.Range(0, meteorPrefab.Length);
		return meteorPrefab[index];
	}
}
