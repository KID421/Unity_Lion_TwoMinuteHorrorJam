using UnityEngine;

public class HorrorObject : MonoBehaviour, ITriggerEvent
{
    /// <summary>
    /// 允許子類別覆寫觸發事件
    /// </summary>
    public virtual void TriggerEvent()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "玩家") TriggerEvent();
    }
}
