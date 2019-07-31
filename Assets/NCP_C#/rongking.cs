using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using Totalk;
using UnityEngine.SceneManagement;

public class rongking : MonoBehaviour {
    //戎地首领
    public GameObject background;//聊天背景框
    public GameObject player;//玩家
    public GameObject Speaker;//正在说话的人
    public GameObject speaktext;//对话聊天框
    public GameObject punctuation;//任务标记点
    public GameObject EndGame;//结束游戏图片
    private bool checkidenty=false;//验证是否为当前物体触碰
    private int[] firstspeaknum;
    private int[] firstspeaknum1;
    private int[] firstspeaknum2;
    private string[] talk = new string[50];
    private string[] talk1 = new string[50];
    private string[] talk2 = new string[50];

    private ITalk Talk = new Talk();//初始化接口

    void Start()
    {
        SetText();//填充聊天文本
        Setfirstspeaknum();//填充第一位说话人的文本序号
    }

    void Update()
    {
        
        switch (Menu.tasknum)
        {
            case 0:
                Talktext(talk, 9, firstspeaknum, 1,2);
                break;
            case 6:
                transform.GetComponent<BoxCollider>().enabled = true;//重新激活物体的触发器功能
                Talktext(talk1, 6, firstspeaknum1, 1,3);
                break;
            case 9:
                transform.GetComponent<BoxCollider>().enabled = true;//重新激活物体的触发器功能
                Talktext(talk2, 5, firstspeaknum2, 1,1);
                
                break;
            case 10:
                EndGame.SetActive(true);
                Invoke("outgame", 3);//游戏结束，三秒后退出游戏
                break;
        }
    }
    private void Talktext(string[] talk, int talklenght, int[] firstspeaknum, int pun1,int pun2)
    {
        if (background.activeSelf == true && checkidenty == true)
        {
            Talk.Speak(background, player, Speaker.GetComponent<UITexture>(), speaktext.GetComponent<UILabel>(), punctuation, talk, talklenght, firstspeaknum, "youyu", "rongking", pun1,pun2);
        }
        if (Talk.EndSpeak())
        {
            transform.GetComponent<BoxCollider>().enabled = false;//交谈结束后，物体的触发器功能结束
            checkidenty = false;
            Talk = new Talk();//结束后要初始化接口
            Menu.tasknum++;//当前任务结束，人物列表序号+1，更新任务列表
        }
    }
    public void SetText()
    {
        talk[0] = "由余拜见大王！";
        talk[1] = "哈哈哈，早就听说先生大名了！快快请起。";
        talk[2] = "谢大王！";
        talk[3] = "我是个爽快人，就不遮遮掩掩了。俺想让你替我做件事。";
        talk[4] = "大王但说无妨.";
        talk[5] = "哈哈哈，爽快。";
        talk[6] = "秦国越来越强大，让我寝食难安，我希望你出使秦国，与秦国结成城下之盟。";
        talk[7] = "由余定不辱使命！";
        talk[8] = "哈哈哈，去吧！";

        talk1[0] = "一听说我要将你打入死牢，穆公就亲自到后宫挑选了十六名能歌善舞的宫女交由内吏，日夜兼程。";
        talk1[1] = "到达戎国献上美女，说用美女交换汝回去为穆公驾车。";
        talk1[2] = "不过依我看，你还不如十六名美女呢！";
        talk1[3] = "大王不能迷恋女色，应以国事为重。";
        talk1[4] = "如不是秦王要你驾车，寡人现在就一刀杀了你！";
        talk1[5] = "滚滚滚！看见你就烦！";


        talk2[0] = "念在君臣一场，求你放过寡人吧！";
        talk2[1] = "下臣事君，素来忠心为名。下臣现事秦君，秦君交给下臣的任务是灭掉戎国，";
        talk2[2] = "昔日，下臣在大王手下为臣，愿肝胆涂地，死而无憾，但大王逼臣叛主择君。";
        talk2[3] = "下臣坚决执行，以忠心报秦君知遇之恩！";
        talk2[4] = "（遂斩下戎王宣子首级）";
        
    }

    private void Setfirstspeaknum()
    {
        int[] num = { 0, 2, 4, 6 };
        int[] num1 = {3};
        int[] num2 = { 1,2,3,4 };
        firstspeaknum = num;
        firstspeaknum1 = num1;
        firstspeaknum2 = num2;
    }
    //退出游戏
    public void Outgame()
    {
        SceneManager.LoadScene("genealogyUI_Yu");//退出游戏后跳转到UI界面
    }
    public void OnTriggerEnter(Collider other)
    {
        if (transform.name == "rongking") checkidenty = true;
        background.SetActive(true);//激活聊天背景
        
    }
    public void OnTriggerExit(Collider other)
    {

    }
}
