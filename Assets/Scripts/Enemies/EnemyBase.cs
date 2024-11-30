using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;


namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public Collider colisor;
        public FlashColor flashColor;
        public ParticleSystem particleSystem;
        public float startLife = 10f;

        [SerializeField]private float _currentLife;

        [Header("Animation")]
        [SerializeField] private AnimationBase _animationBase;

        [Header("Start Animation")]
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;

        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            ResetLife();
            if (startWithBornAnimation)
            {
                BornWithAnimation();
            }
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }

        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            if (colisor != null) colisor.enabled = false;
            Destroy(gameObject, 3f);
            PlayAnimationByTrigger(AnimationType.DEATH);
        }

        public void OnDamage(float f)
        {
            if (flashColor != null) flashColor.Flash();
            if (particleSystem != null) particleSystem.Emit(15);
            _currentLife -= f;

            if (_currentLife <= 0)
            {
                Kill();
            }
        }

        #region ANIMATION
        public void BornWithAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }
        #endregion

        //debug 
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                OnDamage(5);
            }
        }

        public void Damage(float damage)
        {
            OnDamage(damage);
        }
    }
}
