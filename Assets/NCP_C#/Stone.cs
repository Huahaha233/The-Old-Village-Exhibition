using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using Totalk;

public class Stone : MonoBehaviour {
    public GameObject Tips;//提示用户按下F键与npc交谈
    public GameObject background;//聊天背景框
    public GameObject player;//玩家
    public GameObject punctuation;//任务标记点
    public Image Speaker;//正在说话的人
    public Text speaktext;//对话聊天框
    private bool istalk = false;//判断是否是聊天的状态
    private int[] firstspeaknum;
    private string[] talk = new string[50];

    private ITalk Talk = new Talk();//初始化接口
    // Use this for initialization
    void Start()
    {
        SetText();//填充聊天文本
        Setfirstspeaknum();//填充第一位说话人的文本序号
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && (Tips.activeSelf == true))
        {
            background.SetActive(true);//激活聊天背景
            player.transform.GetComponent<FirstPersonController>().enabled = false;//用户不能移动
            istalk = true;
        }
        if (istalk == true) Talk.Speak(background, player, Speaker, speaktext, punctuation, talk, 11, firstspeaknum, "player", "Stone",0,0);
        if (Talk.EndSpeak())//聊天结束
        {
            istalk = false;
        }
    }
    
    public void SetText()
    {
        talk[0] = "咯吱咯吱咯吱...";
        talk[1] = "什么声音？";
        talk[2] = "小伙子，你好啊！";
        talk[3] = "啊！";
        talk[4] = "你是人是鬼啊！";
        talk[5] = "我是你面前的雕塑啊！";
        talk[6] = "你骗人！雕塑怎么会动！";
        talk[7] = "我啊，其实是这个村庄的守护神！";
        talk[8] = "我已经在这生活100年了。";
        talk[9] = "你想听我和这个村落的故事吗？";
        talk[10] = "不想！拜拜了您！";

    }
    private void Setfirstspeaknum()
    {
        int[] num = { 1, 3, 4, 6, 9 };
        firstspeaknum = num;
    }
    public void OnTriggerEnter(Collider other)
    {
        Tips.SetActive(true);//激活UI
    }
    public void OnTriggerExit(Collider other)
    {
        Tips.SetActive(false);//关闭UI
    }
}
