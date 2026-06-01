using Unity.VisualScripting;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    private bool _waiting;

    [SerializeField] private Food _foodState;

    private void Start()
    {
        _foodState = (Food)Random.Range(0, 4);
        Debug.Log(_foodState);
    }
}
