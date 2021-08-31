using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdScript : MonoBehaviour
{
    [SerializeField] string gameId;

    public string placementId = "bannerPlacement";
    public bool testMode = true;

    void Start()
    {
        // Ads testing script
#if UNITY_IOS
            gameId = gameId ?? "3145513";
#elif UNITY_ANDROID
            gameId = gameId ?? "3145512";
#else
        gameId = "";
#endif
        // Initialize the SDK if you haven't already done so:
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }
}