using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public GunBase gunBase;
    public Transform gunPosition;

    private GunBase _currentGun;

    [SerializeField] private List<GunBase> _gunList = new List<GunBase>();

    protected override void Init()
    {
        base.Init();

        CreateGun();

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();

        inputs.Gameplay.Weapon1.performed += x => SwapWeapon1();
        inputs.Gameplay.Weapon2.performed += x => SwapWeapon2();
    }

    private void CreateGun()
    {
        _currentGun = Instantiate(gunBase, gunPosition);

        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    void CreateGun(GunBase gun)
    {
        _currentGun = Instantiate(gun, gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void CancelShoot()
    {
        Debug.Log("Cancel Shoot!");
        _currentGun.StopShoot();
    }

    private void StartShoot()
    {
        _currentGun.StartShoot(); 
        Debug.Log("Start Shoot!");
    }

    void SwapWeapon1()
    {
        CreateGun(_gunList[0]);
    }
    void SwapWeapon2()
    {
        CreateGun(_gunList[1]);
    }
}
