using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DBRObjects
{
    public class RandomPosCoinSpawner : CoinsSpawner
    {

        // Start is called before the first frame update
        void OnEnable()
        {
            int chanceOfSpawn = (int)(Spawners.Count / ChanceOfSpawn);
            int Spawn = Random.Range(0, chanceOfSpawn);

            if (Spawn < Spawners.Count)
            {
                Spawners[Spawn].SetActive(true);
            }
        }

        private void OnDisable()
        {
            foreach (GameObject obj in Spawners)
            {
                obj.SetActive(false);
            }
        }


    }
}