using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectileBase;

    public Transform positionToShoot;
    public float tempoEntreShoot;
    public Transform playerReference;
    public float Velocidade = 50f;

    private Coroutine _currentCorrotina;

    protected virtual IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(tempoEntreShoot);
        }
    }

    public virtual void Shoot()
    {
        var projectile = Instantiate(projectileBase);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
        projectile.Velocidade = Velocidade;
    }

    public void StartShoot()
    {
        StopShoot();
        _currentCorrotina = StartCoroutine(ShootCoroutine());
    }

    public void StopShoot()
    {
        if (_currentCorrotina != null) StopCoroutine(_currentCorrotina);
    }
}
