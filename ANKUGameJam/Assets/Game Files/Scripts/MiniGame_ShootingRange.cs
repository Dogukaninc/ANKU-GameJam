using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MiniGame_ShootingRange : MonoBehaviour, IInteractable
{
    public bool isInteractable;
    public TextMeshProUGUI ammoText;

    public RectTransform weaponParent;

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
            Cursor.visible = false;

            MouseClick();
            GunController();

            ShootingRange();
        }

        ammoText.text = currentAmmoCount.ToString() + "/" + maxAmmoCount.ToString();
    }

    //Mouse t�klamas�yla balnolar� vurdu�umuz bir mini oyun=>
    //Devreye girince mouse ortaya ��kar ve �mage alan�n�n d���na ��karamay�z
    public void Ticker()
    {
        tickList[balloonIndex].SetActive(true);
        balloonIndex++;
    }

    public void ShootGun()//Ballon'dan da invoke'luyorum
    {
        currentAmmoCount--;
        Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmoCount > 0)//her ate� etti�imizde bo�a da s�ksak mermi harcas�n diye yapt�m
        {
            ShootGun();
        }
    }

    public void ShootingRange()
    {
        if (ballonList.All(go => go == null))
        {
            Debug.Log("T�m balonlar patlat�ld�");
            CloseShootingRange();
            isGameRunning = false;
            //Oyun bitme aniamsyonu ve durumu
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
        weaponParent.position = new Vector2(Mathf.Clamp(weaponParent.position.x, -890, 670), Mathf.Clamp(weaponParent.position.y, 352 , -140 ));
        weaponParent.position = Input.mousePosition;
    }

    public void Interaction()
    {

        if (isInteractable)
        {
            miniGamePanel.SetActive(true);
            Debug.Log("Puzzle Etkile�ime Girildi!!!");
            GameStateHandler.instance.PauseGame();

            isGameRunning = true;
        }
        else
        {
            return;
        }

    }

}
