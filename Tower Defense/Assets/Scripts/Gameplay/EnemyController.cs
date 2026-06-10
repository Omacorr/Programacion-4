using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyData data;
    public WaypointPath waypointpath;
    private int waypointIndex;
    private float currentHP;
    
    public void MoveAlongPath()
    {
        if (waypointpath == null)
        {
            return;
        }
            
        if (waypointIndex >= waypointpath.waypoints.Length)
        {
            Object.FindFirstObjectByType<BaseHealthSystem>().TakeDamage(20f);
            Destroy(gameObject);
            return;
        }
            Transform destino = waypointpath.GetWaypoint(waypointIndex);
        transform.position = Vector3.MoveTowards(transform.position, destino.position, data.speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, destino.position) < 0.1f)
        {
            waypointIndex++;
        }
    }
    public void TakeDamage(float damage)
    {
        currentHP = currentHP - damage;
        if (currentHP <= 0)
        {
            Object.FindFirstObjectByType<PlayerBuildSystem>().resources += data.reward;
            UIManager.Instance.UpdateHUDrecursos(Object.FindFirstObjectByType<PlayerBuildSystem>().resources);
            Destroy(gameObject);
            return;
        }
    }
    public void Initialize()
    {
        currentHP = data.hp;
        Debug.Log("HP inicializado: " + currentHP + " data: " + data);
    }
    void Update()
    {
        MoveAlongPath();
    }
}
