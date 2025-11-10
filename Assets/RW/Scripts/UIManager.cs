using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [Header("Settings Panel (DOTween)")]
    public RectTransform startButton;
    public RectTransform settingsButton;
    public RectTransform dialog;

    public CanvasGroup dialogCanvasGroup;

    [Header("Slide Menu (Animator)")]
    public Animator contentPanel;
    public Animator gearImage;

    [Header("DOTween Animation Settings")]
    public float animationDuration = 0.5f;

    [Tooltip("Play")]
    public Vector2 startButtonTargetPos;

    [Tooltip("Settings")]
    public Vector2 settingsButtonTargetPos;

    [Tooltip("Panel Settings")]
    public Vector2 dialogTargetPos;

    private Vector2 startButtonOriginalPos;
    private Vector2 settingsButtonOriginalPos;
    private Vector2 dialogOriginalPos;

    void Awake()
    {
        startButtonOriginalPos = startButton.anchoredPosition;
        settingsButtonOriginalPos = settingsButton.anchoredPosition;
        dialogOriginalPos = dialog.anchoredPosition;

        if (dialogCanvasGroup)
        {
            dialogCanvasGroup.alpha = 0;
            dialogCanvasGroup.interactable = false;
            dialogCanvasGroup.blocksRaycasts = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("RocketMouse");
    }

    public void OpenSettings()
    {
        startButton.DOAnchorPos(startButtonTargetPos, animationDuration).SetEase(Ease.OutBack);
        settingsButton.DOAnchorPos(settingsButtonTargetPos, animationDuration).SetEase(Ease.OutBack);

        dialog.DOAnchorPos(dialogTargetPos, animationDuration).SetEase(Ease.OutBack);
        dialogCanvasGroup.DOFade(1, animationDuration);
        dialogCanvasGroup.interactable = true;
        dialogCanvasGroup.blocksRaycasts = true;
    }

    public void CloseSettings()
    {
        startButton.DOAnchorPos(startButtonOriginalPos, animationDuration).SetEase(Ease.InBack);
        settingsButton.DOAnchorPos(settingsButtonOriginalPos, animationDuration).SetEase(Ease.InBack);

        dialog.DOAnchorPos(dialogOriginalPos, animationDuration).SetEase(Ease.InBack);
        dialogCanvasGroup.DOFade(0, animationDuration);
        dialogCanvasGroup.interactable = false;
        dialogCanvasGroup.blocksRaycasts = false;
    }
    public void ToggleMenu()
    {
        bool isHidden = contentPanel.GetBool("isHidden");
        contentPanel.SetBool("isHidden", !isHidden);
        gearImage.SetBool("isHidden", !isHidden);
    }
}