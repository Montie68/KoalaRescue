using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DBRObjects
{
    public abstract class CoinsSpawner : MonoBehaviour
    {
        [Range(0f, 1.0f)]
        public float ChanceOfSpawn = 1.0f;
        public List<GameObject> SpawObject = null;
        // Start is called before the first frame update

        void Awake()
        {
            Begin();
        }
        public virtual void Begin()
        {
            if (SpawObject == null)
            {
                Debug.LogError("No Coin Spawners Assigned");
                SpawObject = new List<GameObject>();
                Application.Quit();
            }
        }
    }
}