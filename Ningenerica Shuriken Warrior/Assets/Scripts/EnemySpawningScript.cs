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
    private float spawning_speed_increment_cooldown_timer_;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spawning_cooldown_timer_ = 0.5f;
        spawning_speed_increment_cooldown_timer_ = 5.0f;
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

        //every x seconds, the amount of enemies spawned increases
        if (spawning_speed_increment_cooldown_timer_ > 0)
        {
            spawning_speed_increment_cooldown_timer_ -= Time.deltaTime;
        }
        else
        {
            {
                spawning_speed_multiplier_ *= 0.90f;
                spawning_speed_increment_cooldown_timer_ = 6.0f;
            }
        }
    }
    
    //spawn enemies directly with this script
    private void spawnRandomEnemy()
    {
        // first, generate random number between 0 and array size -1
        // the Random.Range returns an int from min (inclusive) to max (exclusive!)
        // so we don't need to apply -1 to get our correct array position
        int random_index_from_array = Random.Range(0, enemy_prefabs_.Length);
        
        //instantiate the randomly chosen prefab
        var random_enemy_created = Instantiate(enemy_prefabs_[random_index_from_array]);

        if (random_enemy_created != null)
        {
            //second random float between +3 and -2
            float random_offset = Random.Range(-2.0f, 3.0f);
        
            //move that prefab to y = 0 + random number, and x = 10
            float x = this.transform.position.x;
            float y = this.transform.position.y + random_offset;
            float z = this.transform.position.z;
            random_enemy_created.position = new Vector3(x,y,z);
        }

    }
    
}
