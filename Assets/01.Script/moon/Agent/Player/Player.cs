using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum PlayerStateType
{
    Dash,
    Rotation
}
public class Player : Agent
{
    #region component region
    [field: SerializeField] public InputReader InputCompo { get; private set; }
    public PlayerData DataCompo => (PlayerData)dataCompo;
    //public PlayerWeapon WeaponCompo => (PlayerWeapon)weaponCompo;
    public GrapplingHook HookCompo;
    public PlayerRotationAttack RotationAttackCompo;
    PlayerWeaponSwitch playerWeaponSwitch;
    [SerializeField]PlayerSkillController skillController;
    PlayerElementLevel playerElementLevel;
    #endregion
    public Vector2 moveDir;
    public float DashTime { get; private set; }
    private int count = 0;
    private float rotationAttackCoolTimer;
    protected override void Awake()
    {
        base.Awake();
        playerWeaponSwitch = GetComponent<PlayerWeaponSwitch>();
        weaponCompo = playerWeaponSwitch.SwitchWeapons(0);
        HookCompo = GetComponent<GrapplingHook>();
        RotationAttackCompo = GetComponent<PlayerRotationAttack>();
        playerElementLevel = GetComponent<PlayerElementLevel>();
        DashTime = 0;
        InputCompo.OnAttackKeyEvent += SwitchAttack;
        InputCompo.OnHookEvent += HookCompo.Hook;
        InputCompo.OnSwitchEvent += SwitchWeapon;
        InputCompo.OnSkillEvent += UseSkill;
    }
    protected override void Update()
    {
        base.Update();
        if(DashTime > 0)
        {
            DashTime -= Time.deltaTime;
        }
    }
    private void SwitchWeapon()
    {
        count = (count + 1) % 5;
        weaponCompo = playerWeaponSwitch.SwitchWeapons(count);
    }
    public void SetDashTime()
    {
        DashTime = DataCompo.dashCoolTime;
    }
    private void UseSkill()
    {
        if (playerElementLevel.ElementLevel[weaponCompo.elementType] >= 3)
        {
            skillController.UseSkill(weaponCompo.elementType);
        }
    }
    public override void InitializeState()
    {
        foreach (StateType stateType in Enum.GetValues(typeof(StateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"Player{enumName}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            StateEnum.Add(stateType, state);
        }
        foreach (PlayerStateType stateType in Enum.GetValues(typeof(PlayerStateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"Player{enumName}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            PlayerStateEnum.Add(stateType, state);
        }
    }
    
}
