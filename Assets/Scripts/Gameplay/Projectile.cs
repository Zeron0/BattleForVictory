using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage = 25;
    [SerializeField] private float _projectileFlightVelocity = 100;

    private Rigidbody _rigidbody;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Fly();
    }

    private void Fly()
    {
        Vector3 nextPosition = transform.position + transform.forward * _projectileFlightVelocity * Time.deltaTime;

        _rigidbody.MovePosition(nextPosition);
    }

    private void HitByProjectile(IDamageable damageable)
    {
        damageable.TakeDamage(_damage);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable damageable))
        {
            HitByProjectile(damageable);
        }
    }
}
