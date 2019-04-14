using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemies
{
    public class SpawnerGroup : MonoBehaviour
    {
        [Header("WARNING! Spawners Must be Assigned!")]
        public List<EnemiesSpawner> Spawners;

        // Start is called before the first frame update
        private void Awake()
        {
            if (Spawners == null)
            {
                Debug.LogError("No Enemy Spawners Assigned");
                Spawners = new List<EnemiesSpawner>();
                Application.Quit();
            }
            foreach (EnemiesSpawner spawner in Spawners)
            {
                spawner.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            int spawner = Random.Range(0, Spawners.Count);
            Debug.Log("Spawner: " + spawner.ToString());

            for (int i = 0; i  < Spawners.Count; i++)
            {
                if (i == spawner)
                {
                    Spawners[i].gameObject.SetActive(true);
                }
                else Spawners[i].gameObject.SetActive(false);

            }
        }
    }
}
