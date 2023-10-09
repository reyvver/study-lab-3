using System;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
	// Cоздаем переменные для менеджера игры,
	// префаба снаряда, скорости, ограничения движения
	// и скорострельности
	[SerializeField] private ShootingSet[] sets;
	public GameManager gameManager;
	public float speed = 10f;
	public float xLimit = 7;


	float elapsedTime = 0;

	[Serializable]
	private class ShootingSet
	{
		public Bullet bulletPrefab;
		public float reload;
	}

	private ShootingSet current;
	private int setId;
	private bool shipStopped;
	private Vector2 screenBounds;

	private void Awake()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		var sp = GetComponent<SpriteRenderer>();
		screenBounds.x -= sp.sprite.bounds.size.x/2;
		screenBounds.y-= sp.sprite.bounds.size.y/2;
		setId = 1;
		gameManager.Stop += StopShip;
		ChangeSet();
	}

	private void StopShip()
	{
		shipStopped = true;
		transform.GetComponent<Animator>().enabled = false;
	}

	void Update()
	{
		if (shipStopped) return;
		elapsedTime += Time.deltaTime;

		float xInput = Input.GetAxis("Horizontal");
		float yInput = Input.GetAxis("Vertical");
		transform.Translate(xInput * speed * Time.deltaTime, yInput * speed * Time.deltaTime, 0f);
		
		Vector3 position = transform.position;
		position.x = Mathf.Clamp(position.x, -screenBounds.x, screenBounds.x);
		position.y = Mathf.Clamp(position.y, -screenBounds.y, screenBounds.y);
		transform.position = position;

		if (elapsedTime > current.reload)
		{
			Vector3 spawnPos = transform.position;
			spawnPos += new Vector3(0, 1.2f, 0);
			
			Instantiate(current.bulletPrefab, spawnPos, Quaternion.identity);
			elapsedTime = 0f; 
		}

		if (Input.GetButtonDown("Jump"))
		{
			ChangeSet();
		}
	}

	private void ChangeSet()
	{
		setId = setId > 0 ? 0 : 1;
		current = sets[setId];
		elapsedTime = 0;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		gameManager.PlayerDied();
	}
}
