using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using Totalk;

public class Qinbed : MonoBehaviour {
    //在秦国的客房中选择睡觉系统
    public GameObject Tips;//按钮提示框
    public GameObject player;//玩家
    public GameObject FPSC;//含有Animator的物体
    public GameObject punctuation;//标记点
    private bool istouch = false;//判断用户是否触碰到床
    private bool issleep = false;//判断用户是否进入睡觉模式
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && istouch == true)
        {
            player.transform.GetComponent<FirstPersonController>().enabled = false;
            FPSC.transform.GetComponent<Animator>().enabled = true;
            //注：这里包含动画的物体在开始时组件"Animator"必须是设置为禁用的，若不禁用物体将无法旋转视角
            //在动画开始前才将"Animator"激活
            issleep = true;
        }
        if (issleep == true) Sleep();
    }

    private void Sleep()
    {
        
        //用户慢慢的走到床边
        if(player.transform.position.z> (float)468.69)
            player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(152, (float)23.715, (float)468.69), Time.deltaTime);
        else
        {
            FPSC.transform.GetComponent<Animator>().SetBool("issleep", true);
            FPSC.transform.GetComponent<Animator>().SetBool("isawake", false);
            Tips.transform.GetChild(0).GetComponent<UILabel>().text = "按空格起床";
            if (Input.GetKeyDown(KeyCode.Space))
            {

                FPSC.transform.GetComponent<Animator>().SetBool("isawake", true);
                FPSC.transform.GetComponent<Animator>().SetBool("issleep", false);
                player.transform.GetComponent<FirstPersonController>().enabled = true;
                issleep = false;
                //结束睡眠状态后，取消目标点，并标记下一任务地点
                punctuation.transform.GetChild(4).gameObject.SetActive(false);
                //在与阎王的聊天结束后，小地图上的戎王所在地的红色标点必须消失
                punctuation.transform.GetChild(3).gameObject.SetActive(true);
                //下一个任务地点在小地图上显示出来

                Menu.tasknum++;//当前任务结束，人物列表序号+1，更新任务列表
            }
        }
        
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if(Menu.tasknum == 2 || Menu.tasknum == 8)
        {
        //激活提示框
        Tips.GetComponent<TweenPosition>().PlayForward();
        Tips.transform.GetChild(0).GetComponent<UILabel>().text = "按下E睡觉";
        istouch = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        Tips.GetComponent<TweenPosition>().PlayReverse() ;//隐藏提示框
        FPSC.transform.GetComponent<Animator>().enabled = false;
    }
}
