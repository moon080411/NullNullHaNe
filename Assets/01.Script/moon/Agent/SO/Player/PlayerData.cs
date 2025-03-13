using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/Player")]
public class PlayerData : AgentData
{
    public float dashInvincibilityTime;
    public float dashCoolTime;
    public float dashTime;
    public float dashSpeed;
    public float jumpPower;
    public float RotationTime;
    public float RotationSpeed;
    public float RotationRadius;
    public float RotationCoolTime;
}
