using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DBREnemies {
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemyActionTrigger : MonoBehaviour
    {
        [HideInInspector]
        public bool isTriggered = false;

        [Header("Trigger Area Bounds")]
        public Bounds boxSize;

       [HideInInspector]
        public BoxCollider2D _collider2D;


        // Start is called before the first frame update
        void Start()
        {
            _collider2D = GetComponent<BoxCollider2D>();
            if (_collider2D.isTrigger == false) _collider2D.isTrigger = true;

        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            isTriggered = true;
        }
    }
}
