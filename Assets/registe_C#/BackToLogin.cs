using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToLogin : MonoBehaviour {

	// Use this for initialization
	public void OnClick()
    {
        //返回登录界面
        SceneManager.LoadScene("login");
    }
}
