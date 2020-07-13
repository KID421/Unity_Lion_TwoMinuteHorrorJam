using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("骷髏頭數量")]
    public Text textCount;
    [Header("結束畫面")]
    public GameObject final;

    private Player player;
    private int count = 5;

    private void Start()
    {
        player = FindObjectOfType<Player>();

        player.onItem += FindItem;
        player.onDead += GameOver;
        player.onFinal += Final;
    }

    private void Final()
    {
        final.SetActive(true);
        //final.transform.GetChild(0).GetComponent<Text>().text = "恭喜你擺脫詛咒了..?";
        final.transform.GetChild(0).GetComponent<Text>().text = "Congratulations..?";
    }

    private void GameOver()
    {
        final.SetActive(true);
        //final.transform.GetChild(0).GetComponent<Text>().text = "你..已.被..死了....";
        final.transform.GetChild(0).GetComponent<Text>().text = "You..are.dead....";
    }

    private void FindItem()
    {
        count--;
        //textCount.text = "骷髏頭剩餘數量：" + count;
        textCount.text = "Skull：" + count;
    }
}
