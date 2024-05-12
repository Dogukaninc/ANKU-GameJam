using System.Collections.Generic;
using UnityEngine;

public class MiniGame_Carousel : MonoBehaviour, IInteractable
{
    public GameObject carouselPanel;
    bool isGameRunning;
    bool isInteractable;
    public List<GameObject> tickList;

    public int starIndex = 0;

    public bool isChallangeCompleted;
    public bool canCollectRose;

    private void Start()
    {
        isInteractable = true;
    }

    private void Update()
    {
        if (isGameRunning)
        {
            if (starIndex == 3)
            {
                CloseCarousel();
            }
        }

        if (canCollectRose)
        {
            TakeRose();
            canCollectRose = false;
        }
    }

    private void TakeRose()
    {
        UiManager.instance.onPrizePanelOpen?.Invoke();
        isChallangeCompleted = true;
    }

    public void Ticker()
    {
        tickList[starIndex].SetActive(true);
        starIndex++;
    }

    public void CloseCarousel()
    {
        carouselPanel.SetActive(false);
        isInteractable = false;
        canCollectRose = true;
        GameStateHandler.instance.ContinueGame();
        isGameRunning = false;
    }

    public void Interaction()
    {
        if (isInteractable)
        {
            carouselPanel.SetActive(true);
            GameStateHandler.instance.PauseGame();
            isGameRunning = true;
        }
        else
        {
            return;
        }

    }

}
