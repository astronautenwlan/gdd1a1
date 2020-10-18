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
        
        // Check if shooting
        bool is_shooting = Input.GetButton("Fire1");
        is_shooting |= Input.GetButton("Fire2");
        // |=  is a compound assignment. x |= y is the same as x = x | y;
        if (is_shooting)
        {
            PlayerWeaponShootingScript weapon = GetComponent<PlayerWeaponShootingScript>();
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

    // Called when the Object is destroyed
    void Destroy()
    {
        
    }
}
