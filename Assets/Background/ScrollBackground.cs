using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = -2f;
    public float lowerYValue = -20;
    public float upperYValue = 40f;

    private bool stopped;
    private void Awake()
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.Stop += Stop;
        gameManager.SpeedUp += SpeedUp;
    }

    private void SpeedUp()
    {
        speed *= GameManager.speedUpCoef;
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
