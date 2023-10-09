using DefaultNamespace;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10f;

	// Обратите внимание на этот раз это локальная переменная
	GameManager gameManager;
	[SerializeField] private RigidbodyExtension[] bullets;

	void Start()
	{
		// Пока игра не запущена и снарядов на сцене нет, обращаться 
		// к объекту Game Manager приходится через поиск по типу
		// Ссылка на скрипт GameManager сохраняется в переменной gameManager
		gameManager = GameObject.FindObjectOfType<GameManager>();

		foreach (var rb in bullets)
		{
			var angle = rb.Rotation;
			rb.AddForce(rb.transform.up * speed, ForceMode2D.Impulse);
			rb.CollistionEnter += OnCollisionEnter2D;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Destroy(other.gameObject); // Уничтожение метеора 
		gameManager.AddScore(); // Увеличение счета 
		Destroy(gameObject); // Уничтожение снаряда
	}
}
