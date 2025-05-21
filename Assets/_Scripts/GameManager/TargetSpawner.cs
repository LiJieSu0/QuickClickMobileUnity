using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnInterval = 2f; // 初始生成間隔
    public float minInterval = 0.5f; // 最短間隔
    public float intervalDecrease = 0.1f; // 每次縮短間隔
    public RectTransform canvasRect; // Canvas 的 RectTransform
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnTarget();
            timer = 0f;
            spawnInterval = Mathf.Max(minInterval, spawnInterval - intervalDecrease); // 逐漸加快
        }
    }

    void SpawnTarget()
    {
        GameObject target = Instantiate(targetPrefab, canvasRect);
        RectTransform rect = target.GetComponent<RectTransform>();
        // 隨機位置（確保目標在螢幕內）
        Vector2 panelSize = canvasRect.rect.size;

        // 隨機產生位置（以 Panel 中心為原點）
        float x = Random.Range(-panelSize.x / 2, panelSize.x / 2);
        float y = Random.Range(-panelSize.y / 2, panelSize.y / 2);

        // 設定位置
        rect.anchoredPosition = new Vector2(x, y);
    }
}
