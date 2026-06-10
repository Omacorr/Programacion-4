using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Slider coreHealthSlider;
    public TMP_Text resourcesText;
    public TMP_Text oleadaText;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;

    

    public void UpdateHUDnucleo(float vidanucleo)
    {
        coreHealthSlider.value = vidanucleo;
    }

    public void UpdateHUDrecursos(int recursos)
    {
        resourcesText.text = "Recursos: " + recursos;
    }
    
    public void UpdateHUDoleada(int numeroleada)
    {
        oleadaText.text = "N°: " + numeroleada;
    }
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowVictory()
    {
        victoryPanel.SetActive(true);
    }

    void Awake()
    {
        Instance = this;
        UpdateHUDnucleo(100f);
    }
}
