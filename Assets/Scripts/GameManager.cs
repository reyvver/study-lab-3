using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public float minSpeedUp = 3;
	public float current = 25;
	public float speedUpStep = 2;
	public static float speedUpCoef = 1.2f;
	public event Action SpeedUp;
	public event Action Stop;
	
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;

	public static bool Stopped;
	int playerScore = 0;

	private void Awake()
	{
		Invoke(nameof(SpeedUpGame), current);
	}

	public void AddScore(int points=1)
	{
		playerScore+=points;
		scoreText.text = playerScore.ToString();
	}

	public void PlayerDied()
	{
		Stopped = true;
		gameOverText.gameObject.SetActive(true);
		Stop?.Invoke();
	}

	private void SpeedUpGame()
	{
		if (Stopped) return;
		
		current -= speedUpStep;
		if (current <= minSpeedUp) current = minSpeedUp;

		MeteorSpawn.speed *= speedUpCoef;
		SpeedUp?.Invoke();
		Invoke(nameof(SpeedUpGame), current);
	}
}
