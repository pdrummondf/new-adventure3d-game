using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timeToDestroy;

    public int qtdDano = 1;

    public float Velocidade = 10f;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Velocidade);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageable = collision.transform.GetComponent<IDamageable>();

        if (damageable != null) damageable.Damage(qtdDano);

        Destroy(gameObject);
    }
}
