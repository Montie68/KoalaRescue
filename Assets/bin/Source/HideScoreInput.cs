// File By Geoff Newman
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScoreInput : MonoBehaviour
{
    #region Public
    //public members go here
    #endregion

    #region Private
    //private members go here
    [SerializeField] List<GameObject> toHideList = new List<GameObject>();
  #endregion
  // Place all unity Message Methods here like OnCollision, Update, Start ect. 
  #region Unity Messages 
    void Start()
    {
        // make sure player Hasn't got a score of 0
        if (ScoreList.playerScore == 0)
        {
            foreach (GameObject g in toHideList)
            {
                g.SetActive(false);
            }
            return;
        }
        // if the Gobal is is maxed out find if the score quailifies to be added
        if (ScoreList.scoreList.Count >= 100)
        {
            foreach (Tuple<string, int> scores in ScoreList.scoreList)
            {
                if (ScoreList.playerScore > scores.Item2 )
                {
                    // this score is large enough to qualify so don't hide
                       return;
                }
            }
            foreach (GameObject g in toHideList)
            {
                // if the isn't high enough hide the list of object
                g.SetActive(false);
            }
            return;
        }
    }
	
    void Update()
    {
		
    }
  #endregion
  #region Public Methods
	//Place your public methods here

  #endregion
  #region Private Methods
	//Place your public methods here

  #endregion

}
