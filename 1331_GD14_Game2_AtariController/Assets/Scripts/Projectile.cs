using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _lifetime = 5f;
    #region Particle
    [SerializeField] private GameObject _particles;

    void SpawnImpact(Vector3 position)
    {
        Instantiate(_particles, position, Quaternion.identity);
    }
    #endregion

    private Rigidbody _rb;
    private GameObject _source;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _source) return;
        //SpawnImpact(collision.contacts[0].point);
        Destroy(gameObject);
    }

    public void Launch(Vector3 direction, GameObject source)
    {
        _source = source;
        _rb.linearVelocity = direction.normalized * _speed;
        transform.forward = direction;
        Destroy(gameObject, _lifetime);
    }
}
