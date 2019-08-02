using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collider_rong : MonoBehaviour {
    //让用户从戎地的主楼门口进入主楼内部
    //或者从主楼内部出去
    public GameObject Join_tips;
    public GameObject youyu;
    private bool checkidenty=false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Join_tips.GetComponent<TweenPosition>().value != new Vector3(0, 615, 0) && Input.GetKeyDown(KeyCode.F)&&checkidenty==true)
        {
            if (youyu.transform.position.z > 79)
                youyu.transform.position = new Vector3(140, 42, 75);
            else youyu.transform.position = new Vector3(140,38,80);
            checkidenty = false;
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (transform.name == "building_10 loded") 
        {
            checkidenty = true;
            Join_tips.GetComponent<TweenPosition>().PlayForward();
            Join_tips.transform.GetChild(0).transform.GetComponent<UILabel>().text = "按下F";
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        Join_tips.GetComponent<TweenPosition>().PlayReverse();
    }
}
