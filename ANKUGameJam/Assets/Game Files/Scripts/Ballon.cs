using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public MiniGame_ShootingRange range;

    public void OnClick()
    {
        range.onBallonDestroyed?.Invoke();
        Destroy(gameObject);
    }
}
