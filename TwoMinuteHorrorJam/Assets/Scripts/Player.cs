using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(1, 1000)]
    public float speed = 10;
    [Header("旋轉速度"), Range(1, 1000)]
    public float turn = 5;
    [Header("時間介面")]
    public Text textTime;
    [Header("吃到骷髏音效")]
    public AudioClip soundSkull;

    private AudioSource aud;

    /// <summary>
    /// 完成
    /// </summary>
    private bool final;

    /// <summary>
    /// 死亡
    /// </summary>
    private bool dead;

    /// <summary>
    /// 遊戲總時間：兩分鐘
    /// </summary>
    private float time = 120;

    /// <summary>
    /// 定義玩家事件委派
    /// </summary>
    public delegate void delegatePlayerEvent();

    /// <summary>
    /// 玩家時間到就死亡
    /// </summary>
    public event delegatePlayerEvent onDead;

    /// <summary>
    /// 玩家取得道具
    /// </summary>
    public event delegatePlayerEvent onItem;

    /// <summary>
    /// 玩家完成：走到終點
    /// </summary>
    public event delegatePlayerEvent onFinal;

    private Rigidbody rig;
    private Transform cam;

    private int count;
    #endregion

    #region 事件
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
        cam = transform.GetChild(0);

        Cursor.visible = false;
    }

    private void Update()
    {
        Timer();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "骷髏頭")
        {
            onItem();
            Destroy(other.gameObject);
            aud.PlayOneShot(soundSkull);

            count++;

            if (count == 5)
            {
                final = true;
                onFinal();
            }
        }
    }
    #endregion

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        rig.AddForce(transform.forward * v * speed + cam.right * h * speed);

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        //cam.Rotate(y * turn, x * turn, 0, Space.World);

        transform.eulerAngles += new Vector3(0, x * turn, 0);
        cam.localEulerAngles += new Vector3(-y * turn, 0, 0);
    }

    /// <summary>
    /// 計時器：倒數
    /// </summary>
    private void Timer()
    {
        if (dead || final) return;

        time -= Time.deltaTime;
        textTime.text = "Time：" + time.ToString("F0");

        if (time <= 0)
        {
            dead = true;
            onDead();
        }
    }
    #endregion
}
