using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorChangeEffect : MonoBehaviour
{

    public Volume globalVolume;
    private ColorAdjustments colorAdj;
    public float startingValue;
    public float targetSaturation;

    public float gradingSpeed;
    public bool isChallangeCompleted;
    private void Start()
    {
        globalVolume.profile.TryGet(out colorAdj);

        colorAdj.saturation.value = startingValue;
    }

    void Update()
    {
        if (isChallangeCompleted)
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        colorAdj.saturation.value = Mathf.Lerp(colorAdj.saturation.value, targetSaturation, Time.deltaTime * gradingSpeed);
    }

}
