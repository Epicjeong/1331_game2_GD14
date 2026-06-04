
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    //spawn manager is gotten from the spawnmanager in scene to get the spawn location of customer
    public SpawnManager _spawnManager;

    //From public enum named "Food"
    public Food _foodState;

    //which spawn the customer was created at
    private int _tableNumber;

    private void Awake()
    {
        //randomly picks from public enum
        _foodState = (Food)Random.Range(0, System.Enum.GetValues(typeof(Food)).Length);

        //Debug print what food it's chosen
        Debug.Log(_foodState);
    }

    public int SetTableNumber(int spawnLocation)
    {
        _tableNumber = spawnLocation;
        return _tableNumber;
    }

    public void Served()
    {
        _spawnManager.UnoccupySeat(_tableNumber);
        _spawnManager.SpawnCustomer();
        Destroy(gameObject);
    }
}
