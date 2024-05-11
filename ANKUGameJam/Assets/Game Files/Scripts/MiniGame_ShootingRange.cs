using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MiniGame_ShootingRange : MonoBehaviour, IInteractable
{
    public Texture2D crossHair;
    public bool isInteractable;
    public TextMeshProUGUI ammoText;

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
            ShootingRange();
        }

        MouseClick();

        ammoText.text = currentAmmoCount.ToString() + "/" + maxAmmoCount.ToString();

    }

    //Mouse týklamasýyla balnolarý vurduðumuz bir mini oyun=>
    //Devreye girince mouse ortaya çýkar ve ýmage alanýnýn dýþýna çýkaramayýz
    public void Ticker()
    {
        tickList[balloonIndex].SetActive(true);
        balloonIndex++;
    }

    public void ShootGun()
    {
        currentAmmoCount--;
    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Debug.Log("Mouse vurduuaaaaaa");

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                Debug.Log("Mouse vurduu");
                GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = hitInfo.point;
                Debug.Log(hitInfo.collider.name);
            }
        }
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
        Cursor.SetCursor(default, Vector2.zero, CursorMode.ForceSoftware);//Cursor'u custom set etmeye calistik
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
