using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<PlayerLives>().TakeLife();
        Destroy(other.gameObject);
    }
}
