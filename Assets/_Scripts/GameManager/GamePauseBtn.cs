using System;
using UnityEngine;
using UnityEngine.UI;
public class GamePauseBtn : MonoBehaviour
{
    Button btn;
    void Start()
    {
        //TODO change pause sprite
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        GameManager.instance.OnGamePause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
