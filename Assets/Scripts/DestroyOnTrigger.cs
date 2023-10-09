using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		// Уничтожение любого объекта,
		// который соприкасается с дробилкой
		Destroy(other.gameObject);
	}
}
