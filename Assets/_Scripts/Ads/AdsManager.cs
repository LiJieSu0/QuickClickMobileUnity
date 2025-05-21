using UnityEngine;
using UnityEngine.SceneManagement;
public class AdsManager : MonoBehaviour
{
    public delegate void OnAdCompete();
    public event OnAdCompete onAdCompeteHandler;

    public static AdsManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowAds()
    {
        SoundManager.instance.ToggleMute();
        InterstitialAdExample interstitialAdExample=GetComponent<InterstitialAdExample>();
        if (interstitialAdExample != null)
        {
            interstitialAdExample.ShowAd();
        }
        else
        {
            Debug.LogError("InterstitialAdExample component not found!");
        }
    }

    public void HideAds()
    {
        //TODO hide ads;
    }

    public void ReloadGameScene()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(currentScene.name);
    }
    public void OnAdComplete()
    {
        onAdCompeteHandler?.Invoke();
        ReloadGameScene();
    }

}
