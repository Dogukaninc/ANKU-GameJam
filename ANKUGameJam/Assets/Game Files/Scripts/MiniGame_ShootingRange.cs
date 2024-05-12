using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniGame_ShootingRange : MonoBehaviour, IInteractable
{
    public bool isInteractable;
    public TextMeshProUGUI ammoText;

    public RectTransform weaponParent;
    public RectTransform canvasRect;

    [Header(" Puzzle Settings ")]
    public GameObject miniGamePanel;
    public bool isGameRunning;

    public List<GameObject> ballonList = new List<GameObject>();
    public List<GameObject> tickList = new List<GameObject>();

    public int balloonIndex = 0;
    public int currentAmmoCount;
    public int maxAmmoCount;


    public Action onBallonDestroyed;
    public Action onGunShot;

    public GameObject crossHair_Polygon;

    private void OnEnable()
    {
        onBallonDestroyed += Ticker;
        onGunShot += ShootGun;
    }

    private void OnDisable()
    {
        onBallonDestroyed -= Ticker;
        onGunShot -= ShootGun;
    }

    void Start()
    {
        isInteractable = true;
    }

    void Update()
    {
        if (isGameRunning)
        {
            crossHair_Polygon.SetActive(true);
            GunController();
            MouseClick();
            CheckAllBallons();

            if (currentAmmoCount == 0)
            {
                if (ballonList.Count > 0)
                {
                    Debug.Log("Balon kaldý ve mermi bitti");
                    GameStateHandler.instance.GameOver();
                }
            }

        }

        ammoText.text = currentAmmoCount.ToString() + "/" + maxAmmoCount.ToString();
    }

    public void Ticker()
    {
        tickList[balloonIndex].SetActive(true);
        balloonIndex++;
    }

    public void ShootGun()//Ballon'dan da invoke'luyorum
    {
        Debug.Log("Sýktým");
        currentAmmoCount--;
    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmoCount > 0)//her ateþ ettiðimizde boþa da sýksak mermi harcasýn diye yaptým
        {
            if (EventSystem.current.IsPointerOverGameObject()) { return; }
            ShootGun();
        }
    }

    public void CheckAllBallons()
    {
        if (ballonList.All(go => go == null) && currentAmmoCount >= 0)
        {
            Debug.Log("Tüm balonlar patlatýldý");
            CloseShootingRange();
            isGameRunning = false;
        }
    }

    public void CloseShootingRange()
    {
        miniGamePanel.SetActive(false);
        isInteractable = false;
        crossHair_Polygon.SetActive(false);
        GameStateHandler.instance.ContinueGame();
    }

    public void GunController()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 canvasMouseLocalPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, mousePosition, null, out canvasMouseLocalPosition);
        //Debug.Log("MOUSE'nin konumu:" + canvasMouseLocalPosition);

        /*
        float minX = -600, maxX = 700, minY = -300, maxY = 350;

        Vector2 anchoredWeaponPos = weaponParent.anchoredPosition;
        anchoredWeaponPos.x = Mathf.Clamp(anchoredWeaponPos.x, minX, maxX);
        anchoredWeaponPos.y = Mathf.Clamp(anchoredWeaponPos.y, minY, maxY);
        */
        weaponParent.anchoredPosition = canvasMouseLocalPosition;
        //canvasMouseLocalPosition = anchoredWeaponPos;
        //TODO Clamp ile silahýn pozisyonunu kýsýtla

    }

    public void Interaction()
    {
        if (isInteractable)
        {
            miniGamePanel.SetActive(true);
            GameStateHandler.instance.PauseGame();
            isGameRunning = true;
        }
        else
        {
            return;
        }

    }

}
