using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;

namespace Enemies
{
    public class DropBear : Enemy
    {
        public EnemyState BeginingEnemyState;
        private Rigidbody2D rb;
        private float LocalGravity = 0.0f;

        [Serializable]
        public class FallSpeed
        {
            public float Min = 0f;
            public float Max = 0f;
        };

        [SerializeField]
        public FallSpeed fallSpeed;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            SetState(BeginingEnemyState);
        }

        // Update is called once per frame
        void Update()
        {
            EnemyState state = GetState();
            switch(state)
            {
                case EnemyState.ATTACK:
                     rb.isKinematic = false;
                    break;
                case EnemyState.DEAD:
                    Die();
                    break;
                default:
                    break;
            }

        }

        private void FixedUpdate()
        {
            LevelManager levelManager = FindObjectOfType<LevelManager>();
           
            LocalGravity =  (levelManager.Speed - levelManager.InitialSpeed) ;

            if (LocalGravity < fallSpeed.Min) LocalGravity = fallSpeed.Min;
            else if (LocalGravity > fallSpeed.Max) LocalGravity = fallSpeed.Max;

            rb.gravityScale = LocalGravity;
        }
        private void OnDisable()
        {
            
        }
        public override void Die()
        {
            // TODO add enemy death animations
            rb.isKinematic = true;
            gameObject.SetActive(false);
            SetState(EnemyState.IDEL);
        }
    }
}
