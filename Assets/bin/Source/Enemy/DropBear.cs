using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class DropBear : Enemy
    {
        public EnemyState BeginingEnemyState;
        // Start is called before the first frame update
        void Start()
        {
            SetState(BeginingEnemyState);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
