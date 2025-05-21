using UnityEngine;

public class DamagedInvincibility : MonoBehaviour
{
    [SerializeField]
        private float _invincibilityDuration;
    private Invincibility _invincibility; // Reference to the Invincibility component
    
    private void Awake()
    {
        _invincibility = GetComponent<Invincibility>(); // Get the Invincibility component
    }
    
    
    public void StartInvincibility()
    {
        _invincibility.StartInvincibility(_invincibilityDuration); // Start the invincibility effect
    }
}
