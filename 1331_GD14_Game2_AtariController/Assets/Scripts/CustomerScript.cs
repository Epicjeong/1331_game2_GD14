using Unity.VisualScripting;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    //Bool to see if they are wait for food or not
    private bool _waiting;

    //From public enum named "Food"
    [SerializeField] private Food _foodState;

    private void Start()
    {
        //randomly picks from public enum
        _foodState = (Food)Random.Range(0, System.Enum.GetValues(typeof(Food)).Length);

        //Debug print what food it's chosen
        Debug.Log(_foodState);
    }
}
