﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting_Script : MonoBehaviour
{
    private WeaponShootingScript[] weapons;

    void Awake()
    {
        //Get all Weapon shooting Scripts in attached child objects
        weapons = GetComponentsInChildren<WeaponShootingScript>();
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //for each weapon in your child objects, carry out the attack
        foreach (WeaponShootingScript weapon in weapons)
        {
            //auto fire enemy weapons
            if ((weapon != null) && weapon.canAttack(0))
            {
                weapon.doAttack(false, 0);
            }
        }
    }
}
