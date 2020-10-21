using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeletionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other_collider)
    {
        if (other_collider != null)
        {
            Destroy(other_collider.gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other_collider)
    {
        if (other_collider != null)
        {
            Destroy(other_collider.gameObject);
        }
    }
    
}
