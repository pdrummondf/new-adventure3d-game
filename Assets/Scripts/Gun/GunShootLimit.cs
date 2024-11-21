using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunShootLimit : GunBase
{
    public List<UIGunUpdater> uIGunUpdaters;

    public float maxBullets = 5f;
    public float timeToRecharge = 1f;

    private float _currentBullets;
    private bool _recharging = false;

    private void Awake()
    {
        GetAllUIs();
    }

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
                UpdateUI();
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
            uIGunUpdaters.ForEach(i => i.UpdateValue(time/timeToRecharge));
            yield return new WaitForEndOfFrame();
        }
        _currentBullets = 0;
        _recharging = false;
    }

    private void UpdateUI()
    {
        uIGunUpdaters.ForEach(i => i.UpdateValue(maxBullets, _currentBullets));
    }

    private void GetAllUIs()
    {
        uIGunUpdaters = GameObject.FindObjectsOfType<UIGunUpdater>().ToList();
    }
}
