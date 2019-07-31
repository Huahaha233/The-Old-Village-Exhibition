using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using NGUI;

public class OutFreeWalk : MonoBehaviour {
    public GameObject outgametext;//退出游戏的按钮
    public GameObject FPS;//用户
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && outgametext.GetComponent<UISprite>().alpha == 0)
        {
            FPS.transform.GetComponent<FirstPersonController>().enabled = true;
            //激活退出游戏的按钮
            //outgametext.SetActive(true);
            outgametext.GetComponent<TweenAlpha>().to = 1;
            outgametext.GetComponent<TweenAlpha>().PlayForward();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && outgametext.GetComponent<UISprite>().alpha == 1)
        {
            FPS.transform.GetComponent<FirstPersonController>().enabled = false;
            //取消退出游戏的按钮
            outgametext.GetComponent<TweenAlpha>().PlayReverse();
            //outgametext.SetActive(false);
        }
        
    }
    public void Click()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
