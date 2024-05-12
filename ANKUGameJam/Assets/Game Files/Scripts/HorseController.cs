using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : MonoBehaviour
{
    [Header(" Horse Settings")]
    public float movingDownForce;
    public float movingUpForce;

    public MiniGame_Carousel miniGame_Carousel;

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * movingUpForce, Space.World);
        }
        else
        {
            transform.Translate(Vector2.down * Time.deltaTime * movingDownForce, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            Debug.Log("Oyunu Kaybettin");
            GameStateHandler.instance.GameOver();

        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("1 adet coin aldýn");
            miniGame_Carousel.Ticker();
            Destroy(collision.gameObject);
        }
    }

}
