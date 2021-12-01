using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50f;
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //With collision of zucchini health will get down (-50) until destroy the object
        var health = otherCollider.GetComponent<Health>();
        health.DealDamage(damage);
    }
}
