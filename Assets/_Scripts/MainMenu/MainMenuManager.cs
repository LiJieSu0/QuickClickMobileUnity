using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    Button startBtn;
    Button rankBtn;
    void Start()
    {
        startBtn = GameObject.Find("StartBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(OnStartBtnClick);
        rankBtn = GameObject.Find("RankBtn").GetComponent<Button>();
        rankBtn.onClick.AddListener(OnRankBtnClick);
    }

    private void OnStartBtnClick()
    {
        SceneManager.LoadScene("GameScene");
        // 這裡可以添加其他初始化代碼，例如載入遊戲數據等
    }

    private void OnRankBtnClick()
    {
        // 這裡可以添加顯示排行榜的代碼
        Debug.Log("Rank button clicked");
        // 例如，顯示一個排行榜面板或載入排行榜場景
    }
}
