using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    public void Fire()
    {
        //Fire the zucchini from 'gun' game object
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
