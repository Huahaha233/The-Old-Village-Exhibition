using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//根据碰撞器来判断用户实在戎地还是在秦国
public class CBN : MonoBehaviour {
    public GameObject country;//国家显示框
    private bool istouch = false;//判断用户是第几次触碰到触碰器
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (istouch == false)
        {
            country.SetActive(true);
            country.transform.GetComponentInChildren<Text>().text= "秦国境内";
            istouch = true;
            Invoke("Destory",3);
        }
        else
        {
            country.SetActive(true);
            country.transform.GetComponentInChildren<Text>().text = "戎地";
            istouch = false;
            Invoke("Destory", 3); 
        }
    }
    private void Destory()
    {
        country.SetActive(false);
    }
}
