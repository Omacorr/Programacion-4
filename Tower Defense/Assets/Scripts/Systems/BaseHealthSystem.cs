using UnityEngine;

public class BaseHealthSystem : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    public void OnDeath()
    {
        UIManager.Instance.ShowGameOver();
    }
    public void TakeDamage(float damage)
    {
        currentHP = currentHP - damage;
        UIManager.Instance.UpdateHUDnucleo(currentHP);
        if (currentHP <= 0)
        {
            OnDeath();
        }
    }

}