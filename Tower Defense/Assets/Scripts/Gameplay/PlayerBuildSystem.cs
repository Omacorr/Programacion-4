using UnityEngine;

public class PlayerBuildSystem : MonoBehaviour
{
    public int resources;
    public bool CanAfford(int cost)
    {
        return resources >= cost;
    }
    public void PlaceTower(int cost)
    {
        resources = resources - cost;
        UIManager.Instance.UpdateHUDrecursos(resources);
    }
    void Start()
    {
        UIManager.Instance.UpdateHUDrecursos(resources);
    }
}
