using UnityEngine;
using System.Collections;

public class HorrorMove : HorrorObject
{
    [Header("移動物件")]
    public Transform move;
    [Header("移動位置")]
    public Transform target;
    [Header("移動速度"), Range(0.1f, 30f)]
    public float speed = 5;

    public override void TriggerEvent()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        float dis = Vector3.Distance(move.localPosition, target.localPosition);

        while (dis >= 0.1f)
        {
            move.localPosition = Vector3.Lerp(move.localPosition, target.localPosition, 0.3f * Time.deltaTime * speed);
            yield return null;
        }
    }
}
