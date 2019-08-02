using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using Totalk;

public class qinking : MonoBehaviour {

    //秦穆公对话
    // Use this for initialization
    public GameObject background;//聊天背景框
    public GameObject player;//玩家
    public GameObject Speaker;//正在说话的人
    public GameObject speaktext;//对话聊天框
    public GameObject punctuation;//任务标记点
    private bool checkidenty = false;//验证是否为当前物体触碰
    private int[] firstspeaknum;
    private int[] firstspeaknum1;
    private int[] firstspeaknum2;
    private int[] firstspeaknum3;
    private string[] talk = new string[50];
    private string[] talk1 = new string[50];
    private string[] talk2 = new string[50];
    private string[] talk3 = new string[50];
    private ITalk Talk = new Talk();//初始化接口
    public static int talktime = 0;//聊天的次数，序数，是为了判断玩家第几次聊天，然后根据序数来改变聊天内容
    // Use this for initialization
    void Start()
    {
        SetText();//填充聊天文本
        Setfirstspeaknum();//填充第一位说话人的文本序号
    }

    // Update is called once per frame
    void Update()
    {
        switch (Menu.tasknum)
        {
            case 1:
                Talktext(talk,17,firstspeaknum, 3,4);
                break;
            case 3:
                transform.GetComponent<BoxCollider>().enabled = true;//重新激活物体的触发器功能
                Talktext(talk1, 9, firstspeaknum1, 3,3);
                break;
            case 5:
                transform.GetComponent<BoxCollider>().enabled = true;//重新激活物体的触发器功能
                Talktext(talk2, 9, firstspeaknum2, 3,1);
                break;
            case 7:
                transform.GetComponent<BoxCollider>().enabled = true;//重新激活物体的触发器功能
                Talktext(talk3, 4, firstspeaknum3, 3,1);
                break;
        }
    }

    private void Talktext(string[] talk,int talklenght,int[] firstspeaknum,int pun1,int pun2)
    {
        if (background.GetComponent<TweenPosition>().value != new Vector3(200, -740, 0) && checkidenty == true)
        {
            Talk.Speak(background, player, Speaker.GetComponent<UITexture>(), speaktext.GetComponent<UILabel>(), punctuation, talk, talklenght, firstspeaknum, "youyu", "qinking", pun1,pun2);
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
        talk[0] = "由余拜见大王。";
        talk[1] = "使者快快请起。";
        talk[2] = "寡人喜欢结交有才华的能人贤士，对那种空有其表的庸人素来厌恶。";
        talk[3] = "由先生不远千里从戎国前来，而且身负国君托付之重任，定有过人之识。";
        talk[4] = "寡人曾听一些贤士的治国之道，但多为空谈，过耳而忘。";
        talk[5] = "你能不能给寡人讲讲古代君王得到国家与失去国家的真正原因吗？";
        talk[6] = "下臣愚钝，对治国之道懂得不多。对国家得失曾思考过，下臣认为节俭得国，奢侈失国。";
        talk[7] = "由先生能不能给寡人讲解详细一些？";
        talk[8] = "昔者，尧拥有天下时，用瓦钵子吃饭，用瓦罐子喝水，节俭自律，天下人心悦诚服，百姓爱戴拥护，称为明君。";
        talk[9] = "舜登上国君之位时，用木制食 器，迹涂上黑色的漆。诸侯颇有微词，认为渐向奢侈，参与会盟，竟有十三个国家借故不来。";
        talk[10] = "等到禹继国君之位后，祭祀之用的祭器上不仅上了黑漆，而且还画上红色的图案，垫褥也用丝绸做成，";
        talk[11] = "吃饭用的钵子、碗上有各种各样的小花纹，不服从的国家达到三十三个。";
        talk[12] = "到了殷商时期，天子的生活更加奢侈，不服从领导的诸侯增 加到五十三个。故下臣认为节俭是治理国家的一种办法。";
        talk[13] = "哈哈哈，讲的好！";
        talk[14] = "由先生舟车劳顿，先回客房休息一晚吧，其他的事等明日再说也不迟。";
        talk[15] = "如此甚好。（作揖）";
        talk[16] = "廖荣，带由先生去客房。";

        talk1[0] = "大王！";
        talk1[1] = "由余先生，昨日休息的可好？";
        talk1[2] = "甚好。";
        talk1[3] = "大王，国君宣子派下臣出使秦国，期望能与秦国结成城下之盟。";
        talk1[4] = "寡人也希望与贵国结成城下之盟，但是此事事关重大，急不得。";
        talk1[5] = "不如先生先在这住下，欣赏欣赏这秦国的山水，过些时日再商议此时不迟。";
        talk1[6] = "大王，此事还是先。。。";
        talk1[7] = "哈哈哈，廖荣，带由先生四处转转。";
        talk1[8] = "若是到时候先生玩得不尽兴，我拿你廖荣试问！下去吧。";

        talk2[0] = "大王！";
        talk2[1] = "由余先生，何事找寡人？";
        talk2[2] = "大王，由余已在秦国待了半年，可这结盟之事还未完成，便打算归国，特来向大王请辞。";
        talk2[3] = "寡人听说戎王对大夫在秦的表现不满，声称大夫归去定要严惩。";
        talk2[4] = "大夫如回国，恐遇不测，不如留在秦国帮助寡人成就霸业？";
        talk2[5] = "下臣奉君命出使，成败都要回去向国君告知出使情况，才算完成使命。";
        talk2[6] = "任务没有完成留在它国，定会令天下人耻笑。";
        talk2[7] = "由余先生果然忠心耿耿，寡人会派廖荣护送先生归国。";
        talk2[8] = "多谢大王！";

        talk3[0] = "由余先生，寡人等候你多时了，快随寡人进宫吧。";
        talk3[1] = "下臣入秦这一刻，就知道戎国必被秦所灭。下臣三代为官，受国君厚恩。";
        talk3[2] = "下臣请求大王在郊外建一小屋，下臣要为戎王先守孝三年，以尽最后一片忠心。";
        talk3[3] = "唉！真忠臣也！";

    }
    private void Setfirstspeaknum()
    {
        int[] num = { 0, 6, 8, 9,10,11,12,15};
        int[] num1 = { 0, 2, 3, 6 };
        int[] num2 = { 0, 2, 5, 6 ,8};
        int[] num3 = { 1,2 };
        firstspeaknum = num;
        firstspeaknum1 = num1;
        firstspeaknum2 = num2;
        firstspeaknum3 = num3;
    }
   

    public void OnTriggerEnter(Collider other)
    {
        if (transform.name == "秦穆公" ) checkidenty = true;
        background.GetComponent<TweenPosition>().PlayForward();//激活聊天背景
    }
    public void OnTriggerExit(Collider other)
    {

    }
}
