using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;

namespace DBREnemies
{
    public class DropBear : Enemy
    {
        public EnemyState BeginingEnemyState = EnemyState.IDEL;
        private Rigidbody2D rb;
        private float LocalGravity = 0.0f;

        public FallSpeed fallSpeed;

        // Start is called before the first frame update
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
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

            rb.gravityScale = fallSpeed.Clamp(LocalGravity);
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
            base.Die();
        }
    }
}
