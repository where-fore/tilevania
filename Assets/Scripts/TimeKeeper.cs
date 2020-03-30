using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    [SerializeField] private float defaultTimeScale = 1f;

    private void Awake()
    {
        ResetTimeScale();
    }

    public void ResetTimeScale()
    {
        SetTimeScale(defaultTimeScale);
    }

    public void SetTimeScale(float targetTimeScale)
    {
        Time.timeScale = targetTimeScale;
    }
    public void SetTimeScale(float targetTimeScale, float delay)
    {
        StartCoroutine(DelayThenSetTimeScale(targetTimeScale, delay));
    }

    private IEnumerator DelayThenSetTimeScale(float targetTimeScale, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        SetTimeScale(targetTimeScale);
    }

    public void SetTimeScaleForSeconds(float targetTimeScale, float length)
    {
        StartCoroutine(SetTimeScaleThenReset(targetTimeScale, length));
    }
        private IEnumerator SetTimeScaleThenReset(float targetTimeScale, float length)
    {
        SetTimeScale(targetTimeScale);

        yield return new WaitForSecondsRealtime(length);

        ResetTimeScale();
    }
}
