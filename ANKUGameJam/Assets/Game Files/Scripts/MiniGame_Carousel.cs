using System.Collections.Generic;
using UnityEngine;

public class MiniGame_Carousel : MonoBehaviour, IInteractable
{
    public GameObject carouselPanel;
    bool isGameRunning;
    bool isInteractable;
    public List<GameObject> tickList;

    public int starIndex = 0;
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
        GameStateHandler.instance.ContinueGame();
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
