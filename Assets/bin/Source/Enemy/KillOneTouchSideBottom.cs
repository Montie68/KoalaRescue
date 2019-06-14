using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;

namespace DBREnemies {
    public class KillOneTouchSideBottom : KillsPlayerOnTouch
    {
        public Enemy EnemyController = null;
        void Start()
        {
            if (EnemyController == null)
            {
                EnemyController = GetComponent<Enemy>();
                if (EnemyController == null) gameObject.AddComponent<Enemy>();
            }
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y <= -0.9f)
                {
                    EnemyController.Die();
                }
                else
                {
                    base.TriggerEnter(collision.gameObject);
                }
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            foreach (ContactPoint point in collision.contacts)
            {
                if (point.normal.y <= -0.9f)
                {
                    EnemyController.Die();
                }
                else
                {
                    base.TriggerEnter(collision.gameObject);
                }
            }
        }
    }
}
