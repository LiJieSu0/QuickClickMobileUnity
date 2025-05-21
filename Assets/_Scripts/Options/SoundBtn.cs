using UnityEngine;
using UnityEngine.UI;
public class SoundBtn : MonoBehaviour
{
    bool isMute=false;
    Button btn;
    GameObject isMuteObj;
    void Start()
    {
        isMuteObj= GameObject.Find("isMute");
        btn= GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SoundManager.instance.ToggleMute();
        isMute=!isMute;
        isMuteObj.SetActive(!isMute);
    }
}
