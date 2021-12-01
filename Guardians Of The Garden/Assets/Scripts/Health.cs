using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;

    //DealDamage deal with the health of object
    public void DealDamage(float damage)
    {
        //As zucchini hit the object, health will decrease
        health -= damage;
        //If health equals to 0, object will destroy
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
