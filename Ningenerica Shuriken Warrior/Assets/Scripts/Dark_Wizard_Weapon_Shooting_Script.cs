using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark_Wizard_Weapon_Shooting_Script : MonoBehaviour
{
    private WeaponShootingScript weapon;

    void Awake()
    {
        weapon = GetComponent<WeaponShootingScript>();
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((weapon != null) && weapon.canAttack())
        {
            weapon.doAttack(false);
        }
    }
}
