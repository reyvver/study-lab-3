using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidbodyExtension : MonoBehaviour
    {
        public event Action<Collision2D> CollistionEnter;
        private Rigidbody2D _rb;
        public float Rotation => _rb.rotation;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void SetVelocity(Vector2 velocity)
        {
            
        }

        public void AddForce(Vector2 force, ForceMode2D forceMode)
        {
            _rb.AddForce(force, forceMode);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            CollistionEnter?.Invoke(other);
        }
    }
}