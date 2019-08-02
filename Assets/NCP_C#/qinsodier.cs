using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using Totalk;

public class qinsodier : MonoBehaviour {
    //秦国把手士兵
    // Use this for initialization
    public GameObject background;//聊天背景框
    public GameObject player;//玩家
    public GameObject Speaker;//正在说话的人
    public GameObject speaktext;//对话聊天框
    public GameObject punctuation;//任务标记点
    private bool checkidenty = false;//验证是否为当前物体触碰
    private int[] firstspeaknum;
    private string[] talk = new string[50];
    private GameObject[] soldiers;

    private ITalk Talk = new Talk();//初始化接口
    // Use this for initialization
    void Start()
    {
        SetText();//填充聊天文本
        Setfirstspeaknum();//填充第一位说话人的文本序号
        soldiers = GameObject.FindGameObjectsWithTag("qinsoldier");
    }

    // Update is called once per frame
    void Update()
    {

        if (Menu.tasknum > 0) {
            foreach (GameObject Object in soldiers)
            {
                Object.GetComponent<BoxCollider>().isTrigger = true;
            }
            Talktext(talk, 6, firstspeaknum, 2, 3);
        }
        else {
            /*Talktext(talk1, 1, firstspeaknum, 2, 0);*/
            foreach (GameObject Object in soldiers)
            {
                Object.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }

    private void Talktext(string[] talk, int talklenght, int[] firstspeaknum, int pun1, int pun2)
    {
        if (background.GetComponent<TweenPosition>().value != new Vector3(200, -740, 0) && checkidenty == true)
        {
            Talk.Speak(background, player, Speaker.GetComponent<UITexture>(), speaktext.GetComponent<UILabel>(), punctuation, talk, talklenght, firstspeaknum, "youyu", "soldier", pun1, pun2);
        }
        if (Talk.EndSpeak())
        {
            //交谈结束后，物体的触发器功能结束
            soldiers = GameObject.FindGameObjectsWithTag("qinsoldier");
            foreach (GameObject Object in soldiers)
            {
                Object.GetComponent<BoxCollider>().enabled = false;
            }
            checkidenty = false;
            Talk = new Talk();//结束后要初始化接口
        }
    }

    public void SetText()
    {
        talk[0] = "站住！什么人？";
        talk[1] = "吾乃戎地使者由余，千里而来觐见秦王，有要事相商。";
        talk[2] = "原来是由余大人。我们大王已经等候多时了。";
        talk[3] = "那我速速前去。";
        talk[4] = "先生，里边请。";
        talk[5] = "好。";
    }
    private void Setfirstspeaknum()
    {
        int[] num = {1, 3, 5};
        firstspeaknum = num;
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (transform.name == "qincutoff1"|| transform.name == "qincutoff2") checkidenty = true;
        background.GetComponent<TweenPosition>().PlayForward();//激活聊天背景
    }
    public void OnTriggerExit(Collider other)
    {

    }
}
