using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Collectable crystal;
    public bool valid;
    public SpeedAbility speed;
    public JetpackAbility jetpack;
    public NodeShiftingAbility nShift;
    public ProjectileAbility pAbility;

    private void Awake()
    {
        nShift = GetComponent<NodeShiftingAbility>();
        crystal = GetComponent<Collectable>();
    }

    public void Start()
    {
        valid = false;
    }

    //Activtes the players ability
    public void RunAbility(int a, bool testing)
    {
        valid = crystal.SetSpeed(true);//check if the player has collected 8 crystals

        if (valid)
        {
            switch (a)
            {
                //when a is 1 the ability is speed
                case 0:
                    if (!testing)
                    {
                        speed.ActivateSpeed(true, false);
                    }
                    //unit Testing
                    else if (testing)
                    {
                        speed.ActivateSpeed(true, true);
                    }   
                    break;

                //when a is 1 the ability is jetpack
                case 1:
                    if (!testing)
                    {
                        jetpack.ActivateJetpack(true);
                    }
                    break;

                //when a is 2 the ability is projectile teleport
                case 2:
                    if (!testing)
                    {
                        pAbility.ActivateProjectile();
                    }
                    break;

                case 3:
                    nShift.teleport();
                    crystal.UpdateCoins();
                    break;

                default:
                    Console.WriteLine("No Number is found");
                    break;
            }          
        }
    }
    
}
