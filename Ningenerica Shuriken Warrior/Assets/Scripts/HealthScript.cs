using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int hp_ = 2;
    public bool is_the_player_ = false;
    
    public float frozen_cooldown_timer_ = 0f;
    public float frozen_duration_to_apply_ = 2f;

    public Transform explosion_prefab_;

    public Text tracked_hp_field_;

    public void damageMe(int damage_count, int shot_type)
    {
        hp_ -= damage_count;

        if (is_the_player_)
        {
            if (tracked_hp_field_ != null)
            {
                tracked_hp_field_.text = "HP remaining: " + hp_;
            }
        }

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
            else
            {
                int old_score = PlayerPrefs.GetInt("PlayerScoreThisGame");
                int new_score = old_score + 1;
                PlayerPrefs.SetInt("PlayerScoreThisGame", new_score);
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
            if (collided_shot.is_player_shot_ != this.is_the_player_)
            {
                damageMe(collided_shot.damage_inflicted_, collided_shot.shot_type_);
                if (collided_shot.shot_type_ == 2)
                {
                    //todo spawn Explosion
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

                if (collided_shot.shot_type_ != 1 && collided_shot.shot_type_ != 3)
                {
                    Destroy(collided_shot.gameObject);
                }
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
