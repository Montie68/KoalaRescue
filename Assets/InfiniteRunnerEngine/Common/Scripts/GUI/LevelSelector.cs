using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using System.Collections;
using MoreMountains.Tools;
using System.Threading.Tasks;
namespace MoreMountains.InfiniteRunnerEngine
{	
	/// <summary>
	/// Add this component to a button so it can be used to go to a level, or restart the current one
	/// </summary>
	public class LevelSelector : MonoBehaviour
	{
	    public string LevelName;

		/// <summary>
		/// Asks the LevelManager to go to a specified level
		/// </summary>
	    public virtual void GoToLevel()
	    {
	        LevelManager.Instance.GotoLevel(LevelName);
	    }

		/// <summary>
		/// Restarts the current level.
		/// </summary>
	    public virtual void RestartLevel()
	    {
	      	//GameManager.Instance.UnPause();
			LevelManager.Instance.GotoLevel(SceneManager.GetActiveScene().name);
	    }

        /// <summary>
        /// Resumes the game
        /// </summary>
        public virtual void Resume()
        {
            GameManager.Instance.UnPause();
        }
        public async void Continue(int Lives = 1)
        {
            GUIManager.Instance.SetGameOverScreenContinue(false);
            GameManager.Instance.SetStatus(GameManager.GameStatus.GameInProgress);
            GameManager.Instance.SetLives(Lives);
            MMEventManager.TriggerEvent(new MMGameEvent("Continue"));
            GameManager.Instance.UnPause();
            GameManager.Instance.Continues -= 1;
            await Task.Delay(500);
            LevelManager.Instance.Continue();
            GameManager.Instance.AddCoins(-LevelManager.Instance.ContinueCost);
        }

        public void PlayAdContinue(int Lives = 1)
        {
            if (Advertisement.IsReady("rewardedVideo"))
            {
                var options = new ShowOptions { resultCallback = HandleShowResult };
                Advertisement.Show("rewardedVideo", options);
            }
        }

        /// <summary>
        /// Resets the score.
        /// </summary>
        public virtual void ResetScore()
	    {
	    	SingleHighScoreManager.ResetHighScore();
	    }

        private void HandleShowResult(ShowResult result)
        {
            switch (result)
            {
                case ShowResult.Finished:
                    Debug.Log("The ad was successfully shown.");
                    //
                    // YOUR CODE TO REWARD THE GAMER
                    // Give coins etc.
                    GameManager.Instance.AddCoins(LevelManager.Instance.ContinueCost);
                    Continue(1);

                    break;
                case ShowResult.Skipped:
                    Debug.Log("The ad was skipped before reaching the end.");
                    break;
                case ShowResult.Failed:
                    Debug.LogError("The ad failed to be shown.");
                    break;
            }
        }
    }
}
