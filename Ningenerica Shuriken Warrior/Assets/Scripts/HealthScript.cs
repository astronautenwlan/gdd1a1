using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int hp_ = 1;
    public bool is_the_player_ = false;

    public void damageMe(int damage_count)
    {
        hp_ -= damage_count;

        if (hp_ <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // this checks, if it is a shot
        ProjectileScript collided_shot = otherCollider.gameObject.GetComponent<ProjectileScript>();
        
        if (collided_shot != null)
        {
            if (collided_shot.is_player_shot_ != is_the_player_)
            {
                damageMe(collided_shot.damage_inflicted_);
                Destroy(collided_shot.gameObject);
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
