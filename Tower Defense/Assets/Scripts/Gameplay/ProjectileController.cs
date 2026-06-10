using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    public float damage;
    public EnemyController target;
    public void MoveTowardsTarget()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        MoveTowardsTarget();
    }
}
