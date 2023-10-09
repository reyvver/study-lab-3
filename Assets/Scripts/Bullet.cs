using DefaultNamespace;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10f;

	// Обратите внимание на этот раз это локальная переменная
	GameManager gameManager;
	[SerializeField] private RigidbodyExtension[] bullets;
	private int currentBullets;
	void Start()
	{
		// Пока игра не запущена и снарядов на сцене нет, обращаться 
		// к объекту Game Manager приходится через поиск по типу
		// Ссылка на скрипт GameManager сохраняется в переменной gameManager
		gameManager = GameObject.FindObjectOfType<GameManager>();

		foreach (var rb in bullets)
		{
			rb.AddForce(rb.transform.up * speed, ForceMode2D.Impulse);
			rb.CollistionEnter += BulletCollision;
		}

		gameManager.Stop += StopBullets;
		currentBullets = bullets.Length;
	}

	private void StopBullets()
	{
		foreach (var rb in bullets)
		{
			rb.SetStatic();
			rb.CollistionEnter -= BulletCollision;
		}
	}

	private void BulletCollision(GameObject bullet, GameObject other)
	{
		currentBullets--;
		Destroy(bullet.gameObject); 
		if (currentBullets == 0)
		{
			Destroy(gameObject);
		}
	}
}
