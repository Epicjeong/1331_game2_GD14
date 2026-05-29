using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private float _fireRate = 1f;

    private float _nextFireTime;
    public bool CanFire => Time.time >= _nextFireTime;

    public void Fire(Vector3 targetPosition)
    {
        if (!CanFire) return;
        _nextFireTime = Time.time + 1 / _fireRate;
        var direction = (targetPosition - _muzzle.position).normalized;
        SpawnProjectile(direction);
    }

    public void SpawnProjectile(Vector3 direction)
    {
        var projectile = Instantiate(_projectilePrefab, _muzzle.position, Quaternion.LookRotation(direction));
        projectile.Launch(direction, gameObject);
    }
}
