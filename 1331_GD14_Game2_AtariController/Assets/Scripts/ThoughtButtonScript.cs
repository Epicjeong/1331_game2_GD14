using UnityEngine;
using UnityEngine.UI;

public class ThoughtButtonScript : MonoBehaviour
{
    [SerializeField] private CustomerScript _customer;
    private Food _customerFoodType;
    

    [SerializeField] private Camera _mainCamera;

    //Food image
    [SerializeField] private Image _foodImage;
    //Serialized array of sprites of the food
    [SerializeField] private Sprite[] _foodSprite;

    private void Start()
    {
        //can get the customer's wanted food here or in awake
        _customerFoodType = _customer._foodState;

        SetSprite(_customerFoodType);
        _mainCamera = GameManager.Instance.mainCamera;
    }

    private void Update()
    {
        AlignCamera();
    }

    private void SetSprite(Food foodtype)
    {
        //Change the food image
        switch (foodtype)
        {
            case Food.Burger:
                _foodImage.sprite = _foodSprite[0];
                break;
            case Food.Bacon:
                _foodImage.sprite = _foodSprite[1];
                break;
            case Food.Pizza:
                _foodImage.sprite = _foodSprite[2];
                break;
            case Food.Fries:
                _foodImage.sprite = _foodSprite[3];
                break;
            case Food.Smoothie:
                _foodImage.sprite = _foodSprite[4];
                break;
        }
    }

    private void AlignCamera()
    {
        var camXform = _mainCamera.transform;
        var forward = transform.position - camXform.position;
        forward.Normalize();
        var up = Vector3.Cross(forward, camXform.right);
        transform.rotation = Quaternion.LookRotation(forward, up);
    }
}
