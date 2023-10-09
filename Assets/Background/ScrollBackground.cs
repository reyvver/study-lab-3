using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = -2f;
    public float lowerYValue = -20;
    public float upperYValue = 40f;
 
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y <= lowerYValue)
        {
            transform.Translate(0, upperYValue, 0);
        }
    }
}
