using System;
using UnityEngine;
using UnityEngine.UI;
public class TargetClick : MonoBehaviour
{
    Button btn;
    Animator animator;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        animator = GetComponent<Animator>();
    }

    private void OnClick()
    {
        SoundManager.instance.PlayTargetClickSFX();
        GameManager.instance.OnScoreChanged(1); // 增加分數
        animator.Play("ClickedAnim");
    }
    public void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
    }
