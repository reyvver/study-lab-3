using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidbodyExtension : MonoBehaviour
    {
        public event Action<GameObject, GameObject> CollistionEnter;
        private Rigidbody2D _rb;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void AddForce(Vector2 force, ForceMode2D forceMode)
        {
            _rb.AddForce(force, forceMode);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            CollistionEnter?.Invoke(gameObject, other.gameObject);
        }

        private void OnDestroy()
        {
            CollistionEnter?.Invoke(gameObject, null);
        }

        public void SetStatic()
        {
            if (_rb == null) return;
            _rb.bodyType = RigidbodyType2D.Static;
        }
    }
}