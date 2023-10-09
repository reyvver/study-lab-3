using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class BonusSpawner : MonoBehaviour
    {	
	    [FormerlySerializedAs("meteorPrefab")] public GameObject[] bonusPrefabs;

	    public float minSpawnDelay = 30f;
	    public float maxSpawnDelay = 60f;
	    public float spawnXLimit = 6f;

	    private bool spawnStopped;
	    GameManager gameManager;

	    void Start()
	    {
		    Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
		    gameManager = GameObject.FindObjectOfType<GameManager>();
		    gameManager.Stop += StopSpawn;
	    }

	    private void OnDestroy()
	    {
		    gameManager.Stop -= StopSpawn;
	    }

	    private void StopSpawn()
	    {
		    spawnStopped = true;
	    }

	    void Spawn()
	    {
		    if (spawnStopped) return;
		    float random = Random.Range(-spawnXLimit, spawnXLimit);

		    Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
		
		    Instantiate(SelectRand(), spawnPos, Quaternion.identity);
		    Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
	    }

	    private GameObject SelectRand()
	    {
		    var index = Random.Range(0, bonusPrefabs.Length);
		    return bonusPrefabs[index];
	    }
    }
}