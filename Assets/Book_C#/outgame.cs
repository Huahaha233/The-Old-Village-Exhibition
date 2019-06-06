using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        if (Input.GetKeyDown(KeyCode.Escape) && outgametext.activeSelf == false)
        {
            FPS.transform.GetComponent<FirstPersonController>().enabled = false;
            outgametext.SetActive(true);//激活退出游戏的按钮
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && outgametext.activeSelf == true)
        {
            FPS.transform.GetComponent<FirstPersonController>().enabled = true;
            outgametext.SetActive(false);//取消退出游戏的按钮
        }

    }
    public void Click()
    {
        SceneManager.LoadScene("login");
    }
}
