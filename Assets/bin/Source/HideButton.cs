using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.InfiniteRunnerEngine
{
    public class HideButton : MonoBehaviour
    {

        // Update is called once per frame
        void OnEnable()
        {
            if (GameManager.Instance.Gold < LevelManager.Instance.ContinueCost)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }
}