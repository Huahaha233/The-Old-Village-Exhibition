using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using NGUI;

public class Menu : MonoBehaviour {
    public GameObject player;
    public GameObject menu;//菜单UI
    public GameObject tips;//提示
    public static int tasknum = 0;//任务序号，其它文本可调用此公共变量以此来更新人物列表
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)&&(menu.GetComponent<TweenPosition>().value==new Vector3(-1210,40,0)))
        {
            player.transform.GetComponent<FirstPersonController>().enabled = false;
            menu.GetComponent<TweenPosition>().PlayForward();
            Task();
        }else if (Input.GetKeyDown(KeyCode.Escape) && (menu.GetComponent<TweenPosition>().value == new Vector3(-710, 40, 0)))
        {
            player.transform.GetComponent<FirstPersonController>().enabled = true;
            menu.GetComponent<TweenPosition>().PlayReverse();
        }
	}
    //退出游戏
    public void Outgame()
    {
        SceneManager.LoadScene("genealogyUI_Yu");//退出游戏后跳转到UI界面
    }

    public void Task()//任务
    {
        switch(tasknum)
        {
            case 0:
                //见戎王
                menu.transform.GetChild(1).GetComponent<UILabel>().text = "由余是周携王的后人，周携王另起炉灶,与周平王“二王并立”，后来晋文侯杀死周携王，周携王的族人，兵败逃亡于西戎。前往戎地面见戎王。"; 
                break;
            case 1:
                menu.transform.GetChild(1).GetComponent<UILabel>().text = "戎国对日益强大的秦国感到惧怕。国君宣子派大夫由余出使秦国，期望能与秦国结成城下之盟，以化解被吞并的危机。前往秦国面见秦穆公。";
                //出使秦国
                break;
            case 2:
                menu.transform.GetChild(1).GetComponent<UILabel>().text = "前往客房休息。";
                //前去休息
                break;
            case 3:
                menu.transform.GetChild(1).GetComponent<UILabel>().text = "前往目标点与秦穆公交谈城下之盟之事。";
                //秦穆公商讨城下之盟
                break;
            case 4:
                menu.transform.GetChild(1).GetComponent<UILabel>().text = "被秦穆公打发出来，可以四处闲逛，浏览建筑物。";
                //秦国闲逛
                Invoke("Wait", 30);
                Invoke("Destroy", 3);
                break;
            case 5:
                menu.transform.GetChild(1).GetComponent<UILabel>().text = "半年后，城下之盟之事还未有进展，向秦穆公请辞回国。";
                //向秦穆公请辞回国
                break;
            case 6:
                menu.transform.GetChild(1).GetComponent<UILabel>().text = "回戎地见戎王";
                //回戎地见戎王
                break;
            case 7:
                menu.transform.GetChild(1).GetComponent<UILabel>().text = "出走戎地，前往秦国见秦穆公，与秦穆公交谈请求替戎王提前守孝三年。";
                //出走戎地，前往秦国见秦穆公，请求替戎王提前守孝三年
                break;
            case 8:
                menu.transform.GetChild(1).GetComponent<UILabel>().text = "根据地图前往守孝地点守孝。";
                //前往守孝地点
                break;
            case 9:
                menu.transform.GetChild(1).GetComponent<UILabel>().text = "守孝结束，带了秦军攻打戎地，找到戎王。";
                //守孝结束，带了秦军攻打戎地，找到戎王
                break;
        }
    }

    ////提示任务更新
    //private void Tip()
    //{
    //    tips.SetActive(true);
    //    tips.transform.GetComponentInChildren<Text>().text = "任务更新";
    //}

    //tasknum为4时，等待1分钟，让用户浏览建筑
    private void Wait()
    {
        tips.GetComponent<TweenPosition>().PlayForward();
        tips.transform.GetChild(0).GetComponent <UILabel>().text="半年后";
        tasknum++;//任务结束时，tasknum+1
    }

    //销毁（隐藏）提示
    private void Destroy()
    {
        tips.GetComponent<TweenPosition>().PlayReverse();
    }
}
