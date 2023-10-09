using UnityEngine;

public class ShipControl : MonoBehaviour
{
	// Cоздаем переменные для менеджера игры,
	// префаба снаряда, скорости, ограничения движения
	// и скорострельности
	public GameManager gameManager;
	public GameObject bulletPrefab;
	public float speed = 10f;
	public float xLimit = 7;
	public float reloadTime = 0.5f; 

	float elapsedTime = 0;

	void Update()
	{
		// Отсчет времени после выстрела
		elapsedTime += Time.deltaTime;

		// Перемещение игрока влево и вправо
		float xInput = Input.GetAxis("Horizontal");
		transform.Translate(xInput * speed * Time.deltaTime, 0f, 0f);

		// Фиксируем положение корабля по оси x 
		Vector3 position = transform.position;
		position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
		transform.position = position;

		// Огонь клавишей "Пробел". Ввод по умолчанию в InputManager называется "Jump"
		// Срабатывает только в том случае, если время перезарядки уже прошло
		if (Input.GetButtonDown("Jump") && elapsedTime > reloadTime)
		{
			// Создание экземпляра снаряда на расстоянии 1,2 единицы перед игроком
			Vector3 spawnPos = transform.position;
			spawnPos += new Vector3(0, 1.2f, 0);
			Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

			// Сброс таймера отсчета времени после выстрела
			elapsedTime = 0f; 
		}
	}

	// Столкновение метеора с игроком 
	void OnTriggerEnter2D(Collider2D other)
	{
		// GameManager будет знать, что игрок погиб
		gameManager.PlayerDied();
	}
}
