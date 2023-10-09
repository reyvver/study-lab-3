using TMPro;
using UnityEngine;
using UnityEngine.UI; // Обратите внимание на важность
					  // этой строки для интерфейса

public class GameManager : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;

	int playerScore = 0;

	public void AddScore()
	{
		playerScore++;
		// Преобразует счет (число) в строку
		scoreText.text = playerScore.ToString();
	}

	public void PlayerDied()
	{
		gameOverText.gameObject.SetActive(true);

		// Приостанавливает игру
		Time.timeScale = 0;				
	}
}
