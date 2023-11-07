using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private GameObject[] _obstacle;
    [SerializeField] private GameManager _gameManager;
    private float _spawnTime;


    void Update()
    {
        if (Time.time > _spawnTime && _gameManager.gameStarted == true)
        {
            Spawn();
            _spawnTime = Time.time + _timeBetweenSpawn;
        }

    }
    private void Spawn()
    {
        GameObject current = _obstacle[Random.Range(0, _obstacle.Length)];
        float randomY = Random.Range(-2.6f, 2.6f);
        Instantiate(current, transform.position + new Vector3(10, randomY, 0), transform.localRotation);
    }
}
