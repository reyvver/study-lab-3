using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public float minSpeedUp = 3;
	public float current = 25;
	public float speedUpStep = 2;
	public static float speedUpCoef = 1.2f;
	public event Action SpeedUp;
	public event Action Stop;
	
	public GameObject gameOverUI;
	public TextMeshProUGUI scoreText;

	public static bool Stopped;
	int playerScore = 0;

	private void Awake()
	{
		Stopped = false;
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
		gameOverUI.SetActive(true);
		Stop?.Invoke();
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(sceneBuildIndex: 1);
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
