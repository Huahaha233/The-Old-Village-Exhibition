using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

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
        if (free.activeSelf == false) free.SetActive(true);
        else free.SetActive(false);
    }

    //家谱模式模式
    public void Genealogy()
    {
        if (genealogy.activeSelf == false) genealogy.SetActive(true);
        else genealogy.SetActive(false);
    }

    //实物展示模式
    public void ShowThing()
    {
        SceneManager.LoadScene("Exhibition");
    }
    //退书阅读模式
    public void Back()
    {
        player.GetComponent<FirstPersonController>().gameObject.SetActive(true);
        bg.SetActive(false);
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
        if (login.isregister == true) SceneManager.LoadScene("genealogyUI_Yu");
        else tips.SetActive(true);
        
    }
}
