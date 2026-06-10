using UnityEngine;

public class TowerController : MonoBehaviour
{
    public float range;
    public float fireRate;
    public GameObject projectilePrefab;
    public Transform firepoint;
    public float fireCountdown;
    private EnemyController target;

    public void DetectEnemy()
    {
        EnemyController[] enemies = Object.FindObjectsByType<EnemyController>(FindObjectsSortMode.None);
        foreach (EnemyController enemy in enemies)
        {
            //Debug.Log("enemigos encontrados: " + enemies.Length);
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //Debug.Log("distancia: " + distanceToEnemy);
            if (distanceToEnemy <= range)
            {
                target = enemy;
                return;
            }
        }
    }
    public void Aim()
    {
        if (target == null)
        {
            return;
        }
        Vector3 direction = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
    public void Shoot()
    {
        if (target == null)
        {
            return;
        }
        GameObject proj = Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);
        proj.GetComponent<ProjectileController>().target = target;
    }
    private void Update()
    {
        DetectEnemy();
        Aim();
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
}
