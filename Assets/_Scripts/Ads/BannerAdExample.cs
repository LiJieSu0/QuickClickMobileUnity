using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
 
public class BannerAdExample : MonoBehaviour
{
  [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

  [SerializeField] string _androidAdUnitId = "Banner_Android";
  [SerializeField] string _iOSAdUnitId = "Banner_iOS";
  string _adUnitId = null; // This will remain null for unsupported platforms.

  void Start()
  {
    _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
    ? _iOSAdUnitId
    : _androidAdUnitId;

    // Set the banner position:
    Advertisement.Banner.SetPosition(_bannerPosition);

  }
 
  // Implement a method to call when the Load Banner button is clicked:
  public void LoadBanner()
  {
      // Set up options to notify the SDK of load events:
      Advertisement.Banner.SetPosition(_bannerPosition);
      BannerLoadOptions options = new BannerLoadOptions
      {
          loadCallback = OnBannerLoaded,
          errorCallback = OnBannerError
      };

      // Load the Ad Unit with banner content:
      Debug.Log("Loading Banner: " + _adUnitId);
      Advertisement.Banner.Load(_adUnitId, options);
  }

  void OnBannerLoaded()
  {
      Debug.Log("Banner loaded");

  }

  // Implement code to execute when the load errorCallback event triggers:
  void OnBannerError(string message)
  {
      Debug.Log($"Banner Error: {message}");
      // Optionally execute additional code, such as attempting to load another ad.
  }

  // Implement a method to call when the Show Banner button is clicked:
  public void ShowBannerAd()
  {
      // Set up options to notify the SDK of show events:
      BannerOptions options = new BannerOptions
      {
          clickCallback = OnBannerClicked,
          hideCallback = OnBannerHidden,
          showCallback = OnBannerShown
      };

      // Show the loaded Banner Ad Unit:
      Debug.Log("Showing Banner: " + _adUnitId);
      Advertisement.Banner.Show(_adUnitId, options);
  }

  // Implement a method to call when the Hide Banner button is clicked:
  void HideBannerAd()
  {
      // Hide the banner:
      Advertisement.Banner.Hide();
  }

  void OnBannerClicked() { }
  void OnBannerShown() { }
  void OnBannerHidden() { }

  void OnDestroy()
  {

  }
}
