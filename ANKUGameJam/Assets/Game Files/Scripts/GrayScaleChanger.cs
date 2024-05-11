using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayScaleChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private float duration = 1f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void StartGrayScaleRoutine()
    {
        StartCoroutine(GrayScaleRoutine(duration, true));
    }

    public void Reset()
    {
        StartCoroutine(GrayScaleRoutine(duration, false));
    }

    public IEnumerator GrayScaleRoutine(float duration, bool isGrayScale)
    {
        float time = 0;
        while (duration > time)
        {
            float durationFrame = Time.deltaTime;
            float ratio = time / duration;
            float grayAmount = isGrayScale ? ratio : 1 - ratio;

            SetGrayScale(grayAmount);
            time += durationFrame;
            yield return null;
        }

        SetGrayScale(isGrayScale ? 1 : 0);

    }
    public void SetGrayScale(float amount = 1)
    {
        spriteRenderer.material.SetFloat("_GrayScaleAmount", amount);

    }
}
