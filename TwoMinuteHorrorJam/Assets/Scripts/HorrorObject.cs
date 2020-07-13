using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HorrorObject : MonoBehaviour, ITriggerEvent
{
    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        rig.useGravity = false;
        rig.constraints = RigidbodyConstraints.FreezeAll;
    }

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
