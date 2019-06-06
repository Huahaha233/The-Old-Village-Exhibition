using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openclose : MonoBehaviour {
    //关闭或打开古村落物品分类展示UI
    // Use this for initialization
    public GameObject UI;//分类UI
    public GameObject Open_button;//开启按钮
    //打开UI
    public void OPEN()
    {
        UI.SetActive(true);
        Open_button.SetActive(false);//隐藏开启按钮
    }
    //关闭UI
    public void CLOSE()
    {
        UI.SetActive(false);
        Open_button.SetActive(true);//显示开启按钮
    }
}
