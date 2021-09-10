
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DBREnemies
{

    public class EnemiesSpawner : MonoBehaviour
    {
        public GameObject enemy = null;
        public EnemyActionTrigger trigger = null;
        [Header("Editor Rect")]
        public Bounds boxSize;

        private Enemy enemyContorller;

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
            enemyState = enemyContorller.GetState();
            if (trigger.isTriggered && enemyState == EnemyState.IDEL)
            {
                enemyContorller.SetState(EnemyState.ATTACK);
            }
        }
        private void OnEnable()
        {
             _enemy = Instantiate(enemy, transform.position, Quaternion.identity);
            _enemy.transform.SetParent(this.transform.parent);
            enemyContorller = _enemy.GetComponent<Enemy>();


        }
        private void OnDisable()
        {
            trigger.isTriggered = false;
            enemyState =  EnemyState.IDEL;
            Destroy(_enemy);
        }
    }

}