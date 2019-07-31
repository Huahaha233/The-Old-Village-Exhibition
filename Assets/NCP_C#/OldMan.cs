using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using Totalk;
using NGUI;

public class OldMan : MonoBehaviour {
    public GameObject Tips;//提示用户按下F键与npc交谈
    public GameObject background;//聊天背景框
    public GameObject player;//玩家
    public GameObject punctuation;//任务标记点
    public GameObject Speaker;//正在说话的人
    public GameObject speaktext;//对话聊天框
    private bool checkidenty = false;//验证是否为当前物体触碰
    private bool istalk = false;//判断是否是聊天的状态
    private int[] firstspeaknum;
    private string[] talk=new string[50];

    private ITalk Talk = new Talk();//初始化接口
    // Use this for initialization
    void Start () {

        SetText();//填充聊天文本
        Setfirstspeaknum();//填充第一位说话人的文本序号
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && (Tips.GetComponent<TweenPosition>().value.x!=-1260&&checkidenty==true))
        {
            //background.SetActive(true);//激活聊天背景
            background.GetComponent<TweenPosition>().PlayForward();
            player.transform.GetComponent<FirstPersonController>().enabled = false;//用户不能移动
            istalk = true;
        }
        if (istalk == true && checkidenty == true) Talk.Speak(background, player, Speaker.GetComponent<UITexture>(), speaktext.GetComponent<UILabel>(), punctuation, talk, 10, firstspeaknum, "player", "oldman",0,0);
        if (Talk.EndSpeak())//聊天结束
        {
            checkidenty = false;
            istalk = false;
        }
    }
    
    public void SetText()
    {
        talk[0] = "大爷，您好！";
        talk[1] = "小伙子，你好啊！";
        talk[2] = "大爷，这是哪啊？风景真好。";
        talk[3] = "哈哈，小伙子，你是第一次来这吧。";
        talk[4] = "这啊，婺源古村落";
        talk[5] = "如今已经有100年历史了,前不久还被国家评定为物质文化遗产呢！";
        talk[6] = "哇，这么厉害，怪不得风景宜人！";
        talk[7] = "哈哈，小伙子眼光不错，待会玩的开心啊！";
        talk[8] = "好嘞，大爷，再见！";
        talk[9] = "小伙子，再见！";
        
    }

    private void Setfirstspeaknum()
    {
        int[] num = { 0,2,6,8 };
        firstspeaknum = num;
    }
    public void OnTriggerEnter(Collider other)
    {
        //Tips.SetActive(true);//激活UI
        if (transform.name == "oldman") {
                checkidenty = true;
                Tips.transform.GetChild(0).GetComponent<UILabel>().text = "按下F与村长交谈";
        }
        
        Tips.GetComponent<TweenPosition>().PlayForward();
    }
    public void OnTriggerExit(Collider other)
    {
        //Tips.SetActive(false);//关闭UI
        Tips.GetComponent<TweenPosition>().PlayReverse() ;
    }
}
