using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab1 = default;
    [SerializeField] private GameObject _enemyPrefab2 = default;
    [SerializeField] private GameObject _enemyPrefab3 = default;
    [SerializeField] private GameObject[] _powerUpPrefabArray = default;
    [SerializeField] private GameObject _enemyContainer = default;
    private bool _stopSpawning = false;
    private float spawnTime = 3f;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    /**************************************
    * Rôle: Apparaître les ennemis
    **************************************/
    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(spawnTime);
        while (!_stopSpawning)
        {
            float randomNumberEnemy = Random.Range(0, 100);
            Vector3 spawnPosition = new Vector3(11.5f, Random.Range(-3.0f, 2.4f), 0f);
            if(randomNumberEnemy <= 60)
            {
                GameObject newEnemy = Instantiate(_enemyPrefab1, spawnPosition, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
            }
            else if (randomNumberEnemy <= 90)
            {
                GameObject newEnemy = Instantiate(_enemyPrefab2, spawnPosition, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
            }
            else if (randomNumberEnemy < 100)
            {
                GameObject newEnemy = Instantiate(_enemyPrefab3, spawnPosition, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
            }
            yield return new WaitForSeconds(spawnTime);
            if (_uiManager.getScore() % 20 == 0 && !_uiManager.getEstChanger() && _uiManager.getScore() != 0)
            {
                if (spawnTime > 0.4f)
                {
                    spawnTime -= 0.2f;
                    _uiManager.setEstChanger(true);
                }
            }
            else if (_uiManager.getScore() % 500 != 0)
            {
                _uiManager.setEstChanger(false);
            }
        }

    }

    /**************************************
    * Rôle: Apparaître le power up
    **************************************/
    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (!_stopSpawning)
        {
            Vector3 positionSpawn = new Vector3(11.5f, Random.Range(-4.0f, 2.4f), 0f);
            int randomPowerUp = Random.Range(0, _powerUpPrefabArray.Length);
            GameObject newPowerUp = Instantiate(_powerUpPrefabArray[randomPowerUp], positionSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(10.0f, 15.0f));
        }
    }

    public void finJeu()
    {
        _stopSpawning = true;

    }              
}
