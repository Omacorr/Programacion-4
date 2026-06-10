using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyData enemyData;
    public Transform spawnPoint;
    public WaypointPath waypointPath;
    public float spawnInterval;
    public WaveManager waveManager;

    public void SpawnEnemy()
    {
        GameObject enemyObj = Instantiate(enemyData.prefab, spawnPoint.position, Quaternion.identity);
        EnemyController enemyController = enemyObj.GetComponent<EnemyController>();
        enemyController.data = enemyData;
        enemyController.waypointpath = waypointPath;
        Debug.Log("llamando initialize");
        enemyController.Initialize();
    }
    public IEnumerator SpawnWave(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
        waveManager.OnWaveComplete();
    }
}
