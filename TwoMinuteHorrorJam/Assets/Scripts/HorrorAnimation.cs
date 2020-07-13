using UnityEngine;
using System.Collections;

public class HorrorAnimation : HorrorObject
{
    [Header("動畫物件")]
    public Transform target;
    [Header("旋轉角度")]
    public float angle = 130;

    public override void TriggerEvent()
    {
        StartCoroutine(RotateAnimation());
    }

    private IEnumerator RotateAnimation()
    {
        Vector3 targetAngle = target.eulerAngles;
        float targetAngleY = target.eulerAngles.y + angle;
        targetAngle.y = target.eulerAngles.y + angle;

        while (target.eulerAngles.y < targetAngleY)
        {
            target.eulerAngles = Vector3.Lerp(target.eulerAngles, targetAngle, 0.3f * Time.deltaTime * 5);
            yield return null;
        }
    }
}
