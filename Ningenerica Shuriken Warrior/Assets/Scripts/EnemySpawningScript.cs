using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    // This is our class to spawn all enemies.
    // We will use the same code as in WeaponShootingScript
    public Transform[] enemy_prefabs_;
    public float spawning_speed_seconds_ = 1.5f;
    public float spawning_speed_multiplier_ = 1.0f;
    private float spawning_cooldown_timer_;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spawning_cooldown_timer_ = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_prefabs_.Length != 0)
        {
            if (spawning_cooldown_timer_ > 0)
            {
                spawning_cooldown_timer_ -= Time.deltaTime;
            }
            else
            {
                this.spawnRandomEnemy();
                spawning_cooldown_timer_ = spawning_speed_seconds_ * spawning_speed_multiplier_;
            }
        }
        
        
    }
    
    //spawn enemies directly with this script
    private void spawnRandomEnemy()
    {
        
    }
    
}
