
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{

    public class EnemiesSpawner : MonoBehaviour
    {
        public GameObject enemy = null;
        public EnemyActionTrigger trigger = null;
        [Header("Editor Rect")]
        public Bounds boxSize;

        private GameObject _enemy;

        EnemyState enemyState = EnemyState.IDEL;

        // Start is called before the first frame update
        void Start()
        {

            if (enemy == null)
            {
                Debug.LogWarning("No Enemy Actor Added!");
                Destroy(this);
            }
            if (enemy == null)
            {
                trigger = GetComponentInChildren<EnemyActionTrigger>();
                if ( trigger== null)
                {
                    Debug.LogWarning("No Enemy Action Trigger Added!");
                    Destroy(this);
                }
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            if (trigger.isTriggered && enemyState == EnemyState.IDEL)
            {
                Debug.Log("Attack!");
                enemyState = EnemyState.ATTACK;
            }
        }
        private void OnEnable()
        {
             _enemy = Instantiate(enemy, transform.position, Quaternion.identity);
            _enemy.transform.SetParent(this.transform.parent);

        }
        private void OnDisable()
        {
            Destroy(_enemy);
        }
    }

}