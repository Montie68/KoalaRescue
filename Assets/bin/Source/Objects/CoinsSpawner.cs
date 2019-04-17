using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DBRObjects
{
    public abstract class CoinsSpawner : MonoBehaviour
    {
        [Range(0f, 1.0f)]
        public float ChanceOfSpawn = 1.0f;
        public List<GameObject> Spawners = null;
        // Start is called before the first frame update

        public virtual void Awake()
        {
            if (Spawners == null)
            {
                Debug.LogError("No Coin Spawners Assigned");
                Spawners = new List<GameObject>();
                Application.Quit();
            }
        }
    }
}