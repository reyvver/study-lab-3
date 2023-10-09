using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
	// Переменная, которая соответствует префабу метеора
	public GameObject meteorPrefab;
	// Переменные для управления временем появления метеоров
	public float minSpawnDelay = 1f;
	public float maxSpawnDelay = 3f;
	// Переменная для управления появлением метеора в разных местах экрана
	public float spawnXLimit = 6f;

	void Start()
	{
		// Появление и размещение метеоров
		Spawn();
	}

	void Spawn()
	{
		// Метеор создается в случайной позиции по оси x
		float random = Random.Range(-spawnXLimit, spawnXLimit);
		// Определяется положение нового метеора
		Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
		// Инициализируется (создается) метеор в новой точке, 
		// задавая вращение по умолчанию
		Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

		// Функция спауна вызывается снова через случайный промежуток времени
		Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
	}
}
