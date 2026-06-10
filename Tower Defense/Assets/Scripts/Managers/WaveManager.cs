using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    public EnemySpawner enemySpawner;
    private void Awake()
    {
        Instance = this;
    }
    public int currentWave;
    public void StartWave()
    {
        currentWave++;
        UIManager.Instance.UpdateHUDoleada(currentWave);
        StartCoroutine(enemySpawner.SpawnWave(currentWave*3));
    }
    public void OnWaveComplete()
    {
        if (currentWave >= 10)
        {
            UIManager.Instance.ShowVictory();
        }
    }
}
