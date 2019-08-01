using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using NGUI;

public class Book : MonoBehaviour {

    // Use this for initialization
    public GameObject free;
    public GameObject genealogy;
    public GameObject bg;
    public GameObject player;
    public GameObject tips;//提示未注册用户不能游玩家谱模块
    //点击书上的按钮进入场景

    //自由浏览模式
    public void Free()
    {
        BackPlay("election",1);
        if (free.transform.GetChild(0).GetComponent<TweenScale>().value == Vector3.zero) BackPlay("free", 0);
        else
        {
            BackPlay("free", 1);
            BackPlay("election", 0);
        }
    }

    //家谱模式模式
    public void Genealogy()
    {
        BackPlay("election", 1);
        if (genealogy.transform.GetChild(0).GetComponent<TweenScale>().value == Vector3.zero) BackPlay("genealogy", 0);
        else {
            BackPlay("genealogy", 1);
            BackPlay("election", 0);
        }
        
    }

    //实物展示模式
    public void ShowThing()
    {
        BackPlay("election", 1);
        SceneManager.LoadScene("Exhibition");
    }
    //退书阅读模式
    public void Back()
    {
        player.GetComponent<FirstPersonController>().gameObject.SetActive(true);
        BackPlay("election", 1);
        bg.GetComponent<TweenPosition>().PlayReverse();
    }

    //自由浏览模式中建筑1的跳转按钮
    public void Build1()
    {
        SceneManager.LoadScene("building1");
    }
    //家谱模式中余氏家谱的跳转按钮

    public void Genealogy1()
    {
        //判断用户是否为注册用户，然后判断是否开启家谱功能模块
        if (GetUIButton.islogin == true) SceneManager.LoadScene("genealogyUI_Yu");
        else tips.GetComponent<TweenScale>().PlayForward();
    }
    private void BackPlay(string str,int x)
    {
        GameObject[] objects= GameObject.FindGameObjectsWithTag(str);
        foreach (GameObject obj in objects)
        {
            if(x==0) obj.GetComponent<TweenScale>().PlayForward();
                else obj.GetComponent<TweenScale>().PlayReverse();
        }

    }
    
}
