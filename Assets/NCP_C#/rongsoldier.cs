using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using Totalk;

public class rongsoldier : MonoBehaviour
{
    //戎地把守士兵
    public GameObject background;//聊天背景框
    public GameObject player;//玩家
    public GameObject Speaker;//正在说话的人
    public GameObject speaktext;//对话聊天框
    private bool checkidenty = false;//验证是否为当前物体触碰
    public GameObject punctuation;//任务标记点
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
        if (background.activeSelf == true && checkidenty == true)
        {
            Talk.Speak(background, player, Speaker.GetComponent<UITexture>(), speaktext.GetComponent<UILabel>(), punctuation, talk, 9, firstspeaknum, "youyu", "soldier",0,1);
        }
        if (Talk.EndSpeak())
        {
            transform.GetComponent<BoxCollider>().enabled = false;//交谈结束后，物体的触发器功能结束
            checkidenty = false;
        }
    }
    
    public void SetText()
    {
        talk[0] = "站住！什么人？";
        talk[1] = "两位官爷，吾乃周携王的后人由余。";
        talk[2] = "周携王后人，跑这来做甚？";
        talk[3] = "唉，曲沃武公伐晋，无奈兵败流亡于此，还望见上戎地大王一面！";
        talk[4] = "那行，你等着，容我通报一声。";
        talk[5] = "。。。（半个时辰后）";
        talk[6] = "由余先生，我们大王久闻先生大名，现已在大厅等候先生了。";
        talk[7] = "如此甚好，有劳这位壮士了！";
        talk[8] = "先生客气了！";
    }
    private void Setfirstspeaknum()
    {
        int[] num = { 1, 3, 5, 7 };
        firstspeaknum = num;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (transform.name == "rongsodiercutoff") checkidenty = true;
        background.SetActive(true);//激活聊天背景
    }
    public void OnTriggerExit(Collider other)
    {
        
    }
}
