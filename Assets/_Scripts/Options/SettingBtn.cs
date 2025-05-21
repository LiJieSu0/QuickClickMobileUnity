using System;
using UnityEngine;
using UnityEngine.UI;
public class SettingBtn : MonoBehaviour
{
    Button btn;
    GameObject settingMenu;
    bool isMenuOpen = false;
    void Start()
    {
        btn= GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        settingMenu = GameObject.Find("SettingMenu");
        settingMenu.SetActive(isMenuOpen);
    }

    private void OnClick()
    {
        isMenuOpen = !isMenuOpen;
        settingMenu.SetActive(isMenuOpen);
        if (isMenuOpen)
        {
            Time.timeScale = 0; // 暫停遊戲
        }
        else
        {
            Time.timeScale = 1; // 恢復遊戲
        }
    }

}
