﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Out_Yu : MonoBehaviour {

    // Use this for initialization
    public void OnClick()
    {
        //退出展示游戏模块
        SceneManager.LoadScene("SampleScene");
    }
}
