using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int maxShields = 3;

    [HideInInspector] public int currentHealth;
    [HideInInspector] public int currentShields;

    void Start()
    {
        currentHealth = maxHealth;
        currentShields = maxShields;

        if (GameManager.Instance != null)
            GameManager.Instance.UpdateHUD();
    }

    public void TakeDamage(int amount)
    {
        if (currentShields > 0)
            currentShields -= amount;
        else
            currentHealth -= amount;

        if (GameManager.Instance != null)
            GameManager.Instance.UpdateHUD();

        if (currentHealth <= 0)
            GameManager.Instance.GameOver();
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        GameManager.Instance.UpdateHUD();
    }

    public void AddShield(int amount)
    {
        currentShields = Mathf.Min(currentShields + amount, maxShields);
        GameManager.Instance.UpdateHUD();
    }
}
