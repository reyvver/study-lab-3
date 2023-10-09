using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
	// Переменная, которая соответствует префабу метеора
	public GameObject[] meteorPrefab;
	// Переменные для управления временем появления метеоров
	public float minSpawnDelay = 1f;
	public float maxSpawnDelay = 3f;
	// Переменная для управления появлением метеора в разных местах экрана
	public float spawnXLimit = 6f;

	public float step = 0.2f;
	private bool spawnStopped;

	void Start()
	{
		// Появление и размещение метеоров
		Spawn();
		GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
		gameManager.Stop += StopSpawn;
		gameManager.SpeedUp += SpeedUp;
	}

	private void SpeedUp()
	{
		maxSpawnDelay -= step;
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
		// Определяется положение нового метеора
		Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
		// Инициализируется (создается) метеор в новой точке, 
		// задавая вращение по умолчанию
		Instantiate(SelectRandMeteor(), spawnPos, Quaternion.identity);

		// Функция спауна вызывается снова через случайный промежуток времени
		Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay - step));
	}

	private GameObject SelectRandMeteor()
	{
		var index = Random.Range(0, meteorPrefab.Length);
		return meteorPrefab[index];
	}
}
