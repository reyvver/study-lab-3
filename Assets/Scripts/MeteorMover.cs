using UnityEngine;

public class MeteorMover : MonoBehaviour
{
	// Открытая переменная, учитывающая скорость движения метеора
	public float speed = -2f;

	Rigidbody2D rigidBody;

	void Start()
	{
		// Ссылка на компонент Rigidbody2D метеора
		rigidBody = GetComponent<Rigidbody2D>();
		// Задаем начальную скорость метеора 
		rigidBody.velocity = new Vector2(0, speed);
	}
}
