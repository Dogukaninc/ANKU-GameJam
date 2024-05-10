using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KarincaKontrol : MonoBehaviour
{
    public float ziplamaGucu = 10f;
    public Rigidbody2D karincaRigidbody;
    public AudioSource ziplamaSesi;
    public AudioSource carpmaSesi;

    private bool oyunBitti = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !oyunBitti)
        {
            Zipla();
        }
    }

    void Zipla()
    {
        karincaRigidbody.velocity = Vector2.up * ziplamaGucu;
        ziplamaSesi.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        carpmaSesi.Play();
        oyunBitti = true;
        // Oyun bittiðinde yapýlacak iþlemler buraya gelebilir
    }
}
