using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootLimit : GunBase
{
    public float maxBullets = 5f;
    public float timeToRecharge = 1f;

    private float _currentBullets;
    private bool _recharging = false;

    protected override IEnumerator ShootCoroutine()
    {

        if (_recharging) yield break;

        while (true)
        {
            if (_currentBullets < maxBullets)
            {
                Shoot();
                _currentBullets++;
                CheckRecharge();
                yield return new WaitForSeconds(tempoEntreShoot);
            }
        }
    }

    private void CheckRecharge()
    {
        if (_currentBullets >= maxBullets)
        {
            StopShoot();
            StartRecharge();
        }
    }

    private void StartRecharge()
    {
        _recharging = true;
        StartCoroutine(RechargeCoroutine());
    }

    IEnumerator RechargeCoroutine()
    {
        float time = 0;
        while (time < timeToRecharge)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _currentBullets = 0;
        _recharging = false;
    }
}
