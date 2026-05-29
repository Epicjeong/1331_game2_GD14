using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    //direction to face
    private Vector2 _direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //turns the player
    public void Turn(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
        if (_direction == Vector2.zero) return;
        var targetAngle = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }
}
