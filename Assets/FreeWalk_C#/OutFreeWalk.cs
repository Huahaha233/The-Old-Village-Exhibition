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
        if (Input.GetKeyDown(KeyCode.Escape) && outgametext.GetComponent<TweenScale>().value == Vector3.zero)
        {
            FPS.transform.GetComponent<FirstPersonController>().enabled = true;
            outgametext.GetComponent<TweenScale>().PlayForward();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && outgametext.GetComponent<TweenScale>().value == Vector3.one)
        {
            FPS.transform.GetComponent<FirstPersonController>().enabled = false;
            outgametext.GetComponent<TweenScale>().PlayReverse();
        }
        
    }
    public void Click()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
