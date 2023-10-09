using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public float minSpeedUp = 3;
	public float current = 40;
	public float speedUpStep = 2;
	public static float speedUpCoef = 1.2f;
	public event Action SpeedUp;
	public event Action Stop;
	
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	
	int playerScore = 0;

	private void Awake()
	{
		Invoke(nameof(SpeedUpGame), 0);
	}

	public void AddScore()
	{
		playerScore++;
		scoreText.text = playerScore.ToString();
	}

	public void PlayerDied()
	{
		gameOverText.gameObject.SetActive(true);
		Stop?.Invoke();
	}

	private void SpeedUpGame()
	{
		current -= speedUpStep;
		if (current <= minSpeedUp) current = minSpeedUp;

		MeteorMover.speed *= speedUpCoef;
		SpeedUp?.Invoke();
		Invoke(nameof(SpeedUpGame), current);
	}
}
