using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform[] _customerSpawn;
    [SerializeField] private GameObject[] _customer;

    private void Awake()
    {
        
    }

    public void SpawnCustomer()
    {
        int randomCustomer = Random.Range(0, _customer.Length);
        int randomSpawn = Random.Range(0, _customerSpawn.Length);

        var customer = Instantiate(_customer[randomCustomer], _customerSpawn[randomSpawn]);
    }
}
