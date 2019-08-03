using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class genealogy_Yu : MonoBehaviour {
    //余氏家谱切换场景
    public GameObject loadingText;
    public GameObject progressBar;
    private double curProgressValue = 0;
    private double progressValue = 0.8;
    private bool isloding = false;
    // Use this for initialization
    
    // Update is called once per frame
    void Update () {
        if (isloding == true) Loding();
    }
    public void ChangeScene_youyu()
    {
        //切换到由余场景
        //loadingText.gameObject.SetActive(true);
        //progressBar.gameObject.SetActive(true);
        isloding = true;
        Invoke("ToScene",3f);
       
    }
    private void ToScene()
    {
        SceneManager.LoadScene("genealogy1");
    }
    private void Loding()
    {
        if (curProgressValue < progressValue)
        {
            curProgressValue+=0.1;
        }
        loadingText.GetComponent<UILabel>().text = curProgressValue*100 + "%";//实时更新进度百分比的文本显示  
        progressBar.GetComponent<UISprite>().fillAmount = (float)curProgressValue;//实时更新滑动进度图片的fillAmount值  
        if (curProgressValue == 0.8)
        {
            loadingText.GetComponent<UILabel>().text = "加载成功";//文本显示完成OK
        }
    }
}
