using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [Header(" Camera Settings ")]
    public Transform followTarget;
    public Vector3 offset;
    public float followSpeed;

    void Start()
    {

    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, followTarget.position + offset, Time.deltaTime * followSpeed);
    }
}
