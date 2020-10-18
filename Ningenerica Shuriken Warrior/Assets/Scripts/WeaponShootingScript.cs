using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShootingScript : MonoBehaviour
{
    // create a projectile prefab for shooting
    public Transform shot_prefab_;
    
    public float shooting_rate_ = 0.25f;


    private float shoot_cooldown_timer_;
    
    // Start is called before the first frame update
    void Start()
    {
        shoot_cooldown_timer_ = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot_cooldown_timer_ > 0)
        {
            shoot_cooldown_timer_ -= Time.deltaTime;
        }
    }

    public bool canAttack()
    {
        if (shoot_cooldown_timer_ > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    
    // Shooting from another Script:
    public void doAttack(bool is_a_player)
    {
        if (canAttack())
        {
            //set the new cooldown timer
            shoot_cooldown_timer_ = shooting_rate_;
            
            //create the shot
            var shot_transform = Instantiate(shot_prefab_) as Transform;
            
            //assign position
            shot_transform.position = transform.position;
            
            //assign is_player property from function parameter
            ProjectileScript shot = shot_transform.gameObject.GetComponent<ProjectileScript>();
            if (shot != null)
            {
               // shot.is_player_shot_ = ;
            }
            
            //set direction facing away from player
            ObjectMovementScript move = shot_transform.gameObject.GetComponent<ObjectMovementScript>();
            if (move != null)
            {
                move.object_direction_ = this.transform.right;
            }

        }
    }
    
}
