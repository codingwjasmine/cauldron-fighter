using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
        private UnityEngine.UI.Image _healthBarImage; // Reference to the health bar image
    public void UpdateHealthBar(Health health)
    {
        _healthBarImage.fillAmount = health.CurrentHealth / health.MaxHealth; // Update the health bar fill amount based on current health
    }
}
