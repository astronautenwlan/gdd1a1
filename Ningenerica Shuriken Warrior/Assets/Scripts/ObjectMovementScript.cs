using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementScript : MonoBehaviour
{
    public Vector2 object_speed_ = new Vector2(5, 5);
    public Vector2 object_direction_ = new Vector2(-1, 0);

    private Vector2 object_movement_;
    private Rigidbody2D object_rigid_body_component_;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        object_movement_ = new Vector2(object_direction_.x * object_speed_.x, object_direction_.y * object_speed_.y);
        
        HealthScript my_status = GetComponent<HealthScript>();
        if (my_status != null)
        {
            if (my_status.frozen_cooldown_timer_ > 0)
            {
                object_movement_ = new Vector2(0,0);
            }
        }
    }

    void FixedUpdate()
    {
        if (object_rigid_body_component_ == null)
        {
            object_rigid_body_component_ = GetComponent<Rigidbody2D>();
        }

        object_rigid_body_component_.velocity = object_movement_;
    }
}
