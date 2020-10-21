using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int damage_inflicted_ = 1;
    public bool is_player_shot_ = true;
    
    // Start is called before the first frame update
    void Start()
    {
        // This destroys the game object after a few seconds, used in enemy fireballs
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
