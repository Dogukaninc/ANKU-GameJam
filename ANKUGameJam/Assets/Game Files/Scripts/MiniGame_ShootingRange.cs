using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MiniGame_ShootingRange : MonoBehaviour, IInteractable
{
    public Texture2D crossHair;
    public bool isInteractable;

    [Header(" Puzzle Settings ")]
    public GameObject miniGamePanel;
    public bool isGameRunning;

    public List<GameObject> ballonList = new List<GameObject>();
    public List<GameObject> tickList = new List<GameObject>();

    public int balloonIndex = 0;

    public Action onBallonDestroyed;
    private void OnEnable()
    {
        onBallonDestroyed += Ticker;
    }
    private void OnDisable()
    {
        onBallonDestroyed -= Ticker;
    }

    void Start()
    {
        isInteractable = true;
    }

    void Update()
    {
        if (isGameRunning)
        {
            ShootingRange();
        }

    }

    //Mouse týklamasýyla balnolarý vurduðumuz bir mini oyun=>
    //Devreye girince mouse ortaya çýkar ve ýmage alanýnýn dýþýna çýkaramayýz
    public void Ticker()
    {
        tickList[balloonIndex].SetActive(true);
        balloonIndex++;
    }

    public void ShootingRange()
    {
        if (ballonList.All(go => go == null))
        {
            Debug.Log("Tüm balonlar patlatýldý");
            CloseShootingRange();
            isGameRunning = false;
            //Oyun bitme aniamsyonu ve durumu
        }

    }

    public void ChangeCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.SetCursor(crossHair, Vector2.zero, CursorMode.ForceSoftware);//Cursor'u custom set etmeye calistik
        Cursor.visible = true;
    }

    public void CloseShootingRange()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        miniGamePanel.SetActive(false);
        isInteractable = false;
        GameStateHandler.instance.ContinueGame();
    }

    public void Interaction()
    {

        if (isInteractable)
        {
            miniGamePanel.SetActive(true);
            Debug.Log("Puzzle Etkileþime Girildi!!!");
            GameStateHandler.instance.PauseGame();

            isGameRunning = true;
            ChangeCursor();
        }
        else
        {
            return;
        }

    }

    /*
    var rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));
    if (!rayHit.collider)
    {
        return;
    }

    Debug.Log(rayHit.collider.name);
    */

}
