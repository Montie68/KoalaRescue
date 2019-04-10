using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class DropBear : Enemy
    {
        public EnemyState BeginingEnemyState;
        Rigidbody2D rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            SetState(BeginingEnemyState);
        }

        // Update is called once per frame
        void Update()
        {
            if (GetState() == EnemyState.ATTACK)
            {
               rb.isKinematic = false;
            }
        }

        public override void Die()
        {
            // TODO add enemy death animations
            gameObject.SetActive(false);
        }
    }
}
