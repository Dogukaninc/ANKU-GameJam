using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public MiniGame_ShootingRange range;

    public void OnClick()
    {
        range.onGunShot?.Invoke();
        range.onBallonDestroyed?.Invoke();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null) { Debug.Log(collision.name); }
    }
}
