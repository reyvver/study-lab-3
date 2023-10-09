using UnityEngine;
using System.Collections;
using DefaultNamespace;

public class MeteorMover : MonoBehaviour
{
	public GameObject meteorFill;
	public float timeFlash;
	public int hitsToDestroy;
	public ParticleSystem particleSystem;
	Rigidbody2D rigidBody;
	private GameManager gameManager;
	private int lives;
	
	void Start()
	{
	
		lives = hitsToDestroy;
		rigidBody = GetComponent<Rigidbody2D>();
		gameManager = GameObject.FindObjectOfType<GameManager>();
		gameManager.Stop += GameManagerOnStop;
	}
	
	private void LateUpdate()
	{
		if (GameManager.Stopped) return;
		transform.Translate(new Vector2(0, -MeteorSpawn.speed*Time.deltaTime));
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (!other.transform.TryGetComponent(out RigidbodyExtension rg)) return;
		
		lives--;
		if (lives == 0)
		{
			gameManager.AddScore(hitsToDestroy);
			Destroy(gameObject);
		}
		else
		{
			Flash();
		}
	}

	private void Flash()
	{
		StopAllCoroutines();
		StartCoroutine(FlaskCor());
	}

	private IEnumerator FlaskCor()
	{
		float t = 0;
		meteorFill.SetActive(true);
		
		while (t < timeFlash)
		{
			t += Time.deltaTime;
			yield return null;
		}
		meteorFill.SetActive(false);
	}
	
	private void OnDestroy()
	{
		StopAllCoroutines();
		var ps = Instantiate(particleSystem);
		ps.transform.position = rigidBody.position;
		ps.Play();
	}
	
	private void GameManagerOnStop()
	{
		if (rigidBody == null) return;

		rigidBody.bodyType = RigidbodyType2D.Static;
		transform.GetComponent<Animator>().enabled = false;
	}
}
