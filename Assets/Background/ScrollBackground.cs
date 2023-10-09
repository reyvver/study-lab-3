using System;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float maxSpeed = 12f;
    public float speed = -2f;
    public float lowerYValue = -20;
    public float upperYValue = 40f;

    private bool stopped;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if (gameManager == null) return;
        gameManager.Stop += Stop;
        gameManager.SpeedUp += SpeedUp;
    }

    private void OnDestroy()
    {
        if (gameManager == null) return;

        gameManager.Stop -= Stop;
        gameManager.SpeedUp -= SpeedUp;
    }

    private void SpeedUp()
    {
        speed *= GameManager.speedUpCoef;
        if (speed > maxSpeed) speed = maxSpeed;
    }

    private void Stop()
    {
        stopped = true;
    }

    void Update()
    {
        if (stopped) return;
        
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y <= lowerYValue)
        {
            transform.Translate(0, upperYValue, 0);
        }
    }
}
