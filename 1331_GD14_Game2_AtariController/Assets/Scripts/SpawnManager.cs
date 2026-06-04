using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Array of spawn locations
    public Transform[] _customerSpawnLocation;
    //Array of customer prefabs
    [SerializeField] private GameObject[] _customer;
    //list of spawn locations occupied
    public List<int> _occupiedSpawn;

    //highest and lowest amount of customers that can be spawned at a time
    private int _minCustomersSpawned = 1;
    private int _maxCustomersSpawned = 3;

    public void SpawnCustomer()
    {
        int customerAmount = Random.Range(_minCustomersSpawned, _maxCustomersSpawned);
        for (int i = 0;  i < customerAmount; i++)
        {
            int randomCustomer = Random.Range(0, _customer.Length);
            int randomSpawn = Random.Range(0, _customerSpawnLocation.Length);
            if (!_occupiedSpawn.Contains(randomSpawn))
            {
                var customer = Instantiate(_customer[randomCustomer], _customerSpawnLocation[randomSpawn]);
                customer.GetComponent<CustomerScript>().SetTableNumber(randomSpawn);
                customer.GetComponent<CustomerScript>()._spawnManager = this;
                _occupiedSpawn.Add(randomSpawn);
            }
        }
    }

    public void UnoccupySeat(int tableNumber)
    {
        _occupiedSpawn.Remove(tableNumber);
    }

}
