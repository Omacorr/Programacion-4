using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }
    public GameState currentState;

    public void StartGame()
    {
        currentState = GameState.Playing;
    }
    public void EndGame()
    {
        currentState = GameState.Defeat;
    }
}
