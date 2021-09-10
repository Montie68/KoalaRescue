using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MoreMountains.InfiniteRunnerEngine
{
    public class DropBearGameManager : GameManager
    {
        /// <summary>
        /// Each 0.01 second, increments the score by 1/100th of the number of points it's supposed to increase each second
        /// </summary>
        /// <returns>The score.</returns>
        protected override IEnumerator IncrementScore()
        {
            while (true)
            {
                
                if ((GameManager.Instance.Status == GameStatus.GameInProgress) && (_pointsPerSecond != 0))
                {
                    if (LevelManager.Instance.ScoreDistacePoints) SetPoints(LevelManager.Instance.DistanceTraveled);
                    else AddPoints(_pointsPerSecond / 100);
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}