using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float scrollingSpeed;

    void Update()
    {
        transform.Translate(Vector3.left * scrollingSpeed * Time.deltaTime, Space.World);
    }
}
