using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ballon : MonoBehaviour
{
    public MiniGame_ShootingRange miniGame_ShootingRange;
    public void OnClick()
    {

        if (miniGame_ShootingRange.currentAmmoCount > 0)
        {
            miniGame_ShootingRange.onGunShot?.Invoke();
            miniGame_ShootingRange.onBallonDestroyed?.Invoke();

            Debug.Log("Balonu vurdum");
            miniGame_ShootingRange.ballonList.Remove(this.gameObject);
            Destroy(gameObject);
        }
        else
        {
            if (EventSystem.current.IsPointerOverGameObject()) { return; }
            Debug.Log("mermim Yok sýkamýyorum");
            return;
        }



    }
}
