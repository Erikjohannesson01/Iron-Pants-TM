using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log("Hej");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
