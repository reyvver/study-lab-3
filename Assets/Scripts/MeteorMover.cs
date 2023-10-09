using UnityEngine;

public class MeteorMover : MonoBehaviour
{
	// Открытая переменная, учитывающая скорость движения метеора
	public static float speed = -2f;

	Rigidbody2D rigidBody;

	void Start()
	{
		// Ссылка на компонент Rigidbody2D метеора
		rigidBody = GetComponent<Rigidbody2D>();
		// Задаем начальную скорость метеора 
		rigidBody.velocity = new Vector2(0, speed);
		GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
		gameManager.Stop += GameManagerOnStop;
	}

	private void GameManagerOnStop()
	{
		if (rigidBody == null) return;
		rigidBody.bodyType = RigidbodyType2D.Static;
		transform.GetComponent<Animator>().enabled = false;
	}
}
