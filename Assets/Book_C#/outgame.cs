using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NGUI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;//必须引用此变量名，否侧无法获取到第一人称控制器的脚本

public class outgame : MonoBehaviour
{
    public GameObject outgametext;//退出游戏的按钮
    public GameObject FPS;//用户
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && outgametext.GetComponent<TweenScale>().value==Vector3.zero)
        {
            FPS.transform.GetComponent<FirstPersonController>().enabled = false;
            outgametext.GetComponent<TweenScale>().PlayForward();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && outgametext.GetComponent<TweenScale>().value==Vector3.one)
        {
            FPS.transform.GetComponent<FirstPersonController>().enabled = true;
            outgametext.GetComponent<TweenScale>().PlayReverse();
        }

    }
    public void Click()
    {
        SceneManager.LoadScene("login");
    }
}
