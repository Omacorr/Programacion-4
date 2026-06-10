using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    public GameObject towerPrefab;
    public int towerCost;
    private bool isOccupied;
    public void OnClick()
    {
        Debug.Log("click detectado");
        if (isOccupied)
        {
            return;
        }
        if (Object.FindFirstObjectByType<PlayerBuildSystem>().CanAfford(towerCost))
        {
            Object.FindFirstObjectByType<PlayerBuildSystem>().PlaceTower(towerCost);
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isOccupied = true;
        }
    }
}
