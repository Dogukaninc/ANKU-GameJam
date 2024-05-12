using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public Action onPrizePanelOpen;
    public Action onPrizePanelClose;

    public static UiManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        onPrizePanelOpen += OpenPrizePanel;
        onPrizePanelClose += ClosePrizePanel;
    }

    private void OnDisable()
    {
        onPrizePanelOpen -= OpenPrizePanel;
        onPrizePanelClose -= ClosePrizePanel;
    }

    [Header(" Prize Panel ")]
    public Transform prizePanel;

    public void OpenPrizePanel()
    {
        GameStateHandler.instance.PauseGame();
        Cursor.visible = true;
        prizePanel.gameObject.SetActive(true);
        if (prizePanel.gameObject.activeSelf)
        {
            prizePanel.DOScale(Vector3.one, .7f).SetEase(Ease.InQuad);
        }
    }

    public void ClosePrizePanel()
    {
        Cursor.visible = false;
        if (prizePanel.gameObject.activeSelf)
        {
            prizePanel.transform.DOScale(Vector3.zero, 0.7f).SetEase(Ease.InQuad).OnComplete(() =>
            {
                GameStateHandler.instance.ContinueGame();
                prizePanel.gameObject.SetActive(false);
            });
        }

    }

}
