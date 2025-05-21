using UnityEngine;

public class PlayerBoundClamping : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main; 
    }

    private void Update()
    {
        ClampToScreenBounds();
    }

    private void ClampToScreenBounds()
    {
        Vector3 screenPos = _mainCamera.WorldToViewportPoint(transform.position);
        screenPos.x = Mathf.Clamp(screenPos.x, 0.05f, 0.95f); // Adjust these values to set the bounds
        screenPos.y = Mathf.Clamp(screenPos.y, 0.05f, 0.95f); // Adjust these values to set the bounds
        transform.position = _mainCamera.ViewportToWorldPoint(screenPos);
    }
}