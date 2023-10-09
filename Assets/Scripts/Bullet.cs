using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10f;

	// Обратите внимание на этот раз это локальная переменная
	GameManager gameManager; 

	void Start()
	{
		// Пока игра не запущена и снарядов на сцене нет, обращаться 
		// к объекту Game Manager приходится через поиск по типу
		// Ссылка на скрипт GameManager сохраняется в переменной gameManager
		gameManager = GameObject.FindObjectOfType<GameManager>();

		Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = new Vector2(0f, speed);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Destroy(other.gameObject); // Уничтожение метеора 
		gameManager.AddScore(); // Увеличение счета 
		Destroy(gameObject); // Уничтожение снаряда
	}
}
