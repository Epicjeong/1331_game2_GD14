
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    //stores spawn manager to set spawn location to unoccupied
    [SerializeField] private SpawnManager _spawnManager;

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
        Debug.Log(_tableNumber);
        return _tableNumber;
    }

    public void Served()
    {
        _spawnManager._occupiedSpawn.Remove(_tableNumber);
        _spawnManager.SpawnCustomer();
        Destroy(gameObject);
    }
}
