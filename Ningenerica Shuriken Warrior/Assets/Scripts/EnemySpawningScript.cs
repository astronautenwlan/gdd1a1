using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    // This is our class to spawn all enemies.
    // We will use the same code as in WeaponShootingScript
    // The enemy prefabs needs to be filled in unity to choose any number of enemy prefabs to spawn
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
        //random number between 0 and array size-1
        // the Random.Range returns an int from min (inclusive) to max (exclusive!)
        // so we don't need to apply -1 to get our array access
        int enemy_picked_from_array_ = Random.Range(0, enemy_prefabs_.Length);
        
        //instantiate the randomly chosen prefab
        var random_enemy_created = Instantiate(enemy_prefabs_[enemy_picked_from_array_]);
        

        //second random float between +3 and -2
        //move that prefab to y = 0 + random number, and x = 10

    }
    
}
