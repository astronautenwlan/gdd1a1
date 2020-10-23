using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int hp_ = 1;
    public bool is_the_player_ = false;
    
    public float frozen_cooldown_timer_ = 0f;
    public float frozen_duration_to_apply_ = 2f;

    public void damageMe(int damage_count, int shot_type)
    {
        hp_ -= damage_count;

        if (hp_ <= 0)
        {
            Destroy(gameObject);
            if (is_the_player_)
            {            
                //Search for the GameOver Canvas, and activate the buttons
                var game_over = FindObjectOfType<GameOverScript>();
                if (game_over != null)
                {
                    game_over.showButtons();
                }
            }
        }

        if (shot_type == 1)
        {
            frozen_cooldown_timer_ += frozen_duration_to_apply_;
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
                damageMe(collided_shot.damage_inflicted_, collided_shot.shot_type_);
                switch (collided_shot.shot_type_)
                {
                    case 0:
                        break;
                    case 1:
                        //freeze enemy
                        break;
                    case 2:
                        //start explosion
                        break;
                }
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
