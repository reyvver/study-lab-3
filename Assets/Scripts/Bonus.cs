using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bonus : MonoBehaviour
    {
        public float speed = 20;
        public BonusType bonusType;
        public enum BonusType
        {
            Shield,
            Bullets
        }
        GameManager gameManager;
        
        private void Awake()
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();
            gameManager.SpeedUp += SpeedUp;
        }

        private void SpeedUp()
        {
            speed += GameManager.speedUpCoef;
        }

        private void Update()
        {
            if (GameManager.Stopped) return;
            transform.Translate(new Vector2(0, speed*Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.TryGetComponent(out ShipControl ship))
            {
                ship.AddBonus(bonusType);
                Destroy(gameObject);
            }
        }

    }
}