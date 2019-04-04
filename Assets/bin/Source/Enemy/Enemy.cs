using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies {
    public class Enemy : MonoBehaviour
    {
        protected EnemyState enemyState;

        public virtual void SetState(EnemyState _state)
        {
            enemyState = _state;
        }
        public virtual EnemyState GetState( )
        {
            return enemyState;
        }
    }
}
