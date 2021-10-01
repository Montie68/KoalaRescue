using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStep : MonoBehaviour
{
   #region Public
   //public members go here
   public AudioSource audioSource;
  #endregion

  #region Private
  	//private members go here

  #endregion
  // Place all unity Message Methods here like OnCollision, Update, Start ect. 
  #region Unity Messages 
    void Start()
    {
      if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }
	
    void Update()
    {
		
    }
  #endregion
  #region Public Methods
	//Place your public methods here
   public void PlayAudio()
   {
      audioSource.Play();
   }
  #endregion
  #region Private Methods
	//Place your public methods here

  #endregion

}
