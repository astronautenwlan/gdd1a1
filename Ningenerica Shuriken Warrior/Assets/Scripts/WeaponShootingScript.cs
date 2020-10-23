using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class WeaponShootingScript : MonoBehaviour
{
    // create a projectile prefab for shooting
    public Transform shot_prefab_;
    public Transform ice_prefab_;
    public Transform explosion_prefab_;
    public float shooting_rate_ = 0.35f;
    public float shooting_rate_ice_ = 1.0f;
    public float shooting_rate_explosion_ = 1.0f;
    
    private float shooting_cooldown_timer_;
    private float shooting_ice_cooldown_timer_;
    private float shooting_explosion_cooldown_timer_;

    // Start is called before the first frame update
    void Start()
    {
        shooting_cooldown_timer_ = 0f;
        shooting_ice_cooldown_timer_ = 0f;
        shooting_explosion_cooldown_timer_ = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting_cooldown_timer_ > 0) { shooting_cooldown_timer_ -= Time.deltaTime; }
        if (shooting_ice_cooldown_timer_ > 0) { shooting_ice_cooldown_timer_ -= Time.deltaTime; }
        if (shooting_explosion_cooldown_timer_ > 0) { shooting_explosion_cooldown_timer_ -= Time.deltaTime; }
    }

    public bool canAttack(int attack_type)
    {
        HealthScript my_status = GetComponentInParent<HealthScript>();
        if (my_status != null)
        {
            if (my_status.frozen_cooldown_timer_ > 0)
            {
                return false;
            }
        }
        
        switch (attack_type)
        {
            case 0:
                if (shooting_cooldown_timer_ > 0) { return false; }
                break;
            case 1:
                if (shooting_ice_cooldown_timer_ > 0) { return false; }
                break;
            case 2:
                if (shooting_explosion_cooldown_timer_ > 0) { return false; }
                break;
        }
        return true;
    }
    
    
    // Shooting from another Script:
    public void doAttack(bool is_a_player, int shot_type)
    {
        if (shot_type == 0)
        {
            if (canAttack(0))
            {
                //set the new cooldown timer
                shooting_cooldown_timer_ = shooting_rate_;
            
                //create the shot
                var shot_transform = Instantiate(shot_prefab_) as Transform;
            
                //assign position
                shot_transform.position = transform.position;
            
                //
                ProjectileScript shot = shot_transform.gameObject.GetComponent<ProjectileScript>();
                if (shot != null)
                {
                    //set direction facing away from player
                    ObjectMovementScript move = shot_transform.gameObject.GetComponent<ObjectMovementScript>();
                    if (move != null)
                    {
                        move.object_direction_ = this.transform.right;
                    }
                }
            


            }
        }
        else if (shot_type == 1)
        {
            if (canAttack(1))
            {
                //set the new cooldown timer
                shooting_ice_cooldown_timer_ = shooting_rate_ice_;
            
                //create the shot
                var shot_transform = Instantiate(ice_prefab_) as Transform;
            
                //assign position
                shot_transform.position = transform.position;
            
                //
                ProjectileScript shot = shot_transform.gameObject.GetComponent<ProjectileScript>();
                if (shot != null)
                {
                    //set direction facing away from player
                    ObjectMovementScript move = shot_transform.gameObject.GetComponent<ObjectMovementScript>();
                    if (move != null)
                    {
                        move.object_direction_ = this.transform.right;
                    }
                }
            
            }
        }
 
        else if (shot_type == 2)
        {
            if (canAttack(2))
            {
                //set the new cooldown timer
                shooting_explosion_cooldown_timer_ = shooting_rate_explosion_;
            
                //create the shot
                var shot_transform = Instantiate(explosion_prefab_) as Transform;
            
                //assign position
                shot_transform.position = transform.position;
            
                //
                ProjectileScript shot = shot_transform.gameObject.GetComponent<ProjectileScript>();
                if (shot != null)
                {
                    //set direction facing away from player
                    ObjectMovementScript move = shot_transform.gameObject.GetComponent<ObjectMovementScript>();
                    if (move != null)
                    {
                        move.object_direction_ = this.transform.right;
                    }
                }
            
            }
        }
    }
    
}
