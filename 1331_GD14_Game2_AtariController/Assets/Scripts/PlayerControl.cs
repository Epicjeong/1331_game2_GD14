using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerControl : MonoBehaviour
{
    //direction to face
    private Vector2 _direction;

    //Projectile aim and throw
    [SerializeField] private GameObject _target;
    [SerializeField] private ProjectileWeapon _weapon;

    //From public enum named "Food"
    public Food _foodState;
    //display of next thrown food
    public ThoughtButtonScript _thoughtBubble;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FoodState();
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

    //While the aim button is held, shows an outline of the direction the food will be thrown and fires once its let go
    public void Aim(InputAction.CallbackContext context)
    {
        _target.SetActive(true);
        if (context.canceled)
        {
            _target.SetActive(false);
            if (_weapon.CanFire)
            {
                _weapon.Fire(_target.transform.position);
                FoodState();
            }
        }

    }

    private void FoodState()
    {
        _foodState = (Food)Random.Range(0, System.Enum.GetValues(typeof(Food)).Length);
        _thoughtBubble.SetSprite(_foodState);
    }
}
