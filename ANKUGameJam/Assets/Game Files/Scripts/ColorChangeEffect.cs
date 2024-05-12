using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorChangeEffect : MonoBehaviour
{

    public Volume globalVolume;
    private ColorAdjustments colorAdj;
    private ChromaticAberration abreration;

    public float adj_startingValue;
    public float aberation_startingValue;

    public float targetSaturation;
    public float targetIntensity;

    public float gradingSpeed;
    public float intensitySpeed;

    public bool isMissionCompleted;

    bool changeIntensityDirection;

    private void Start()
    {
        globalVolume.profile.TryGet(out colorAdj);
        globalVolume.profile.TryGet(out abreration);

        colorAdj.saturation.value = adj_startingValue;
        abreration.intensity.value = aberation_startingValue;

    }

    void Update()
    {
        if (isMissionCompleted)
        {
            ChangeColor();
            AbsorbationEffect();
        }
    }

    public void ChangeColor()
    {
        colorAdj.saturation.value = Mathf.Lerp(colorAdj.saturation.value, targetSaturation, Time.deltaTime * gradingSpeed);
    }

    public void AbsorbationEffect()
    {

        if (!changeIntensityDirection)
        {
            abreration.intensity.value = Mathf.Lerp(abreration.intensity.value, targetIntensity, Time.deltaTime * intensitySpeed);
        }

        if (abreration.intensity.value >= 0.8f)
        {
            changeIntensityDirection = true;
        }

        if (changeIntensityDirection)
        {
            abreration.intensity.value = Mathf.Lerp(abreration.intensity.value, aberation_startingValue, Time.deltaTime * intensitySpeed);
        }

    }

}
