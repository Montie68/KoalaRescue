using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using MoreMountains.InfiniteRunnerEngine;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(LevelSelector))]
public class RewardedAdsScript : MonoBehaviour, IUnityAdsListener
{

   // private string gameId = "3145513";

    public bool testMode = true;
    [SerializeField] string gameId;


    [SerializeField] Button myButton;
    [SerializeField] LevelSelector levelSelector;
    public int lives = 1;
    public string myPlacementId = "rewardedVideo";

    void Start()
    {
        // Ads testing script
#if UNITY_IOS
            gameId = "3444262";
#elif UNITY_ANDROID
        gameId =  "3444263";
#else
        gameId =  "3444263";
#endif

        myButton = myButton ?? GetComponent<Button>();
        levelSelector = levelSelector ?? GetComponent<LevelSelector>();
        // Set interactivity to be dependent on the Placement’s status:
        

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }
    private void OnEnable()
    {
        StartCoroutine(EnableContinue());
    }
    // Implement a function for showing a rewarded video ad:
    private IEnumerator EnableContinue()
    {
        yield return new WaitForSeconds(1 / 3);
        myButton.gameObject.SetActive(Advertisement.IsReady(myPlacementId));
    }
    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
#if UNITY_WEBGL
        levelSelector.Continue(lives);
#endif
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
#if UNITY_WEBGL
        myButton.interactable = true;
#endif
    }

    public void OnUnityAdsDidFinish( string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            levelSelector.Continue(lives);
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}