using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(IsAttackerInLane())
        {
            //to do change animation state to shooting
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            //to do change animation state to idle
            animator.SetBool("IsAttacking", false);
        }
    }
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }
    private bool IsAttackerInLane()
    {
        //If my lane spawner child count less than or equal to 0
        //Return false
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
       
    }
    public void Fire()
    {
        //Fire the zucchini from 'gun' game object
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
