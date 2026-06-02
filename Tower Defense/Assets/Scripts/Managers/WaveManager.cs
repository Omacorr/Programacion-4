using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public int currentWave;
    public void StartWave()
    {
        currentWave++;
        UIManager.Instance.UpdateHUDoleada(currentWave);
    }
    public void OnWaveComplete()
    {

    }
}
