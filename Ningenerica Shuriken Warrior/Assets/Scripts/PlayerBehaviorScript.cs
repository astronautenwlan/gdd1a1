using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorScript : MonoBehaviour
{
    // Player's general movement. Player speed is set to "public", so we can manage it in the Unity "Inspector" Pane
    public Vector2 player_speed_ = new Vector2(6, 6);
    private Vector2 player_movement_ = new Vector2();
    private Rigidbody2D player_rigidbody_component_;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get Player Input
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        
        // Save that in Movement Variable
        player_movement_ = new Vector2(inputX * player_speed_.x, inputY * player_speed_.y);
        
        //set boundaries, then later set the player inside those
        var dist = (transform.position - Camera.main.transform.position).z;
        var left_border = Camera.main.ViewportToWorldPoint(new Vector3(0.02f, 0, dist) ).x;
        var right_border = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0, dist) ).x;
        var bottom_border = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.05f, dist) ).y;
        var top_border = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.6f, dist) ).y;

        // the Mathf.Clamp sets the min and max boundaries. We add something to the y boundary due to our gaming-floor not spanning the whole y axis
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, left_border, right_border),
            Mathf.Clamp(transform.position.y, bottom_border, top_border),
            transform.position.z);
        
        // Check if the player is shooting
        bool is_shooting = Input.GetButton("Fire1");
        is_shooting |= Input.GetButton("Fire2");
        // |=  is a compound assignment. x |= y is the same as x = x | y;
        if (is_shooting)
        {
            WeaponShootingScript weapon = GetComponent<WeaponShootingScript>();
            if (weapon != null)
            {
                // the argument is boolean is_the_player_
                weapon.doAttack(true);
            }
        }



    }

    // Called every fixed Frame - Use this for Physics
    void FixedUpdate()
    {
        // get the rigidbody Component from Unity and store it in the member variable
        if (player_rigidbody_component_ == null)
        {
            player_rigidbody_component_ = GetComponent<Rigidbody2D>();
        }
        // Now we move the player object accordingly
        player_rigidbody_component_.velocity = player_movement_;
    }

    // Player collision detection with enemies
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision with enemy
        ObjectMovementScript enemy = collision.gameObject.GetComponent<ObjectMovementScript>();
        if (enemy != null)
        {
            //kill enemy
            HealthScript enemy_health = enemy.GetComponent<HealthScript>();
            if (enemy_health != null)
            {
                enemy_health.damageMe(enemy_health.hp_);
            }

            //and damage the player
            HealthScript player_health = this.GetComponent<HealthScript>();
            if (player_health != null)
            {
                player_health.damageMe(1);
            }
        }
    }



    // Called when the Object is destroyed
    void Destroy()
    {
        
    }
}
