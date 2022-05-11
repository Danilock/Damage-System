using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DamageSystem.Attacks
{
    /// <summary>
    /// Base class for attacks.
    /// </summary>
    public abstract class Attack : MonoBehaviour
    {
        #region Attack Settings
        [FormerlySerializedAs("Point")]
        [Header("Attack Settings")] 
        
        [SerializeField] private Transform _point;

        protected Transform Point => _point == null ? transform : _point;
        public bool IgnoreTargetInvulnerability = false;

        #endregion
        
        #region Damage Settings
        [Header("Damage Settings")]
        [SerializeField] protected float DamageAmount;
        [SerializeField] protected LayerMask Layers;
        #endregion

        public UnityEvent OnHit;
        
        /// <summary>
        /// Damageable owning this Attack
        /// </summary>
        public Damageable Owner;
        public abstract void DoAttack();

        protected virtual void Awake()
        {
            if (Owner == null)
                Owner = GetComponent<Damageable>();
        }

        public void SetDamage(float amount) => DamageAmount = amount;
    }
}