using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public MiniGame_ShootingRange miniGame_ShootingRange;
    public void OnClick()
    {
        miniGame_ShootingRange.onGunShot?.Invoke();
        miniGame_ShootingRange.onBallonDestroyed?.Invoke();
        Destroy(gameObject);
    }
}
