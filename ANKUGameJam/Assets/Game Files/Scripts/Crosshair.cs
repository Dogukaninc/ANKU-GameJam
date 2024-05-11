using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void Update()
    {
        Vector3 cursorPos = Input.mousePosition;
        transform.position = cursorPos;
    }
}
