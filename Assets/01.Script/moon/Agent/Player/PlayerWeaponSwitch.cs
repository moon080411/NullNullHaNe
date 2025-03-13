using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerWeaponSwitch : MonoBehaviour
{
    [SerializeField] AgentWeapon NormalWeapon;
    [SerializeField] AgentWeapon FireWeapon;
    [SerializeField] AgentWeapon WaterWeapon;
    [SerializeField] AgentWeapon WindWeapon;
    [SerializeField] AgentWeapon LightningWeapon;

    public AgentWeapon SwitchWeapons(int num)
    {
        switch(num)
        {
            case 0:
                return NormalWeapon;
            case 1:
                return FireWeapon;
            case 2:
                return WaterWeapon;
            case 3:
                return WindWeapon;
            case 4:
                return LightningWeapon;
            default:
                return NormalWeapon;
        }
    }
}
