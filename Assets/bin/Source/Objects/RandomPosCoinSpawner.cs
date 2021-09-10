using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DBRObjects
{
    public class RandomPosCoinSpawner : CoinsSpawner
    {
        private ObjectSpawner[] spawners;
        GameObject _object;

        // Start is called before the first frame update
        public override void Begin()
        {
            base.Begin();
            spawners = GetComponentsInChildren<ObjectSpawner>();
        }
        void OnEnable()
        {
            int chanceOfSpawn = (int)(spawners.Length / ChanceOfSpawn);
            int inst = Random.Range(0, chanceOfSpawn);
            int Formation = Random.Range(0, SpawObject.Count);

            if (inst < spawners.Length)
            {
                _object = Instantiate(SpawObject[Formation], 
                                      spawners[inst].transform.position, 
                                      Quaternion.identity);

                _object.transform.SetParent(spawners[inst].transform.parent);
            }
        }

        private void OnDisable()
        {
            Destroy(_object);
        }


    }
}