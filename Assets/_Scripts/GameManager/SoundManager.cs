using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    AudioClip targetClickSFX;
    [SerializeField]
    AudioSource SFXAudioSource;
    void Start()
    {
        instance = this;

    }

    void Update()
    {
        
    }
    public void PlayTargetClickSFX()
    {
        SFXAudioSource.PlayOneShot(targetClickSFX);
    }
    public void ToggleMute()
    {
        foreach(Transform child in this.transform){
            AudioSource childAudioSource = child.GetComponent<AudioSource>();
            if (childAudioSource != null)
            {
                childAudioSource.mute = !childAudioSource.mute;
            }
        }
    }
}
