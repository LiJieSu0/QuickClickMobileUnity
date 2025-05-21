using UnityEngine;

public class TargetLifeCircle : MonoBehaviour
{
    public float lifeTime = 2f; // 目標的生命週期
    private float timer;
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            GameManager.instance.OnLiveChanged(-1); // 減少生命
            GameManager.instance.OnScoreChanged(-1); // 減少分數            
            Destroy(gameObject); // 超過生命週期後銷毀目標
        }
    }
}
