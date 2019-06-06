using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Tips : MonoBehaviour {
    public GameObject tips;
    public GameObject background;//书的背景UI
    public GameObject Player;
    //Use this for initialization
    [DllImport("user32.dll", EntryPoint = "keybd_event")]
    public static extern void Keybd_event(
       byte bvk,//虚拟键值 ESC键对应的是27
       byte bScan,//0
       int dwFlags,//0为按下，1按住，2释放
       int dwExtraInfo//0
       );

    // Update is called once per frame
    void Update () {
        if (tips.activeSelf == true && Input.GetKeyDown(KeyCode.F))
        {
            OutFirstController();
            Invoke("Judge",0.2f);
        }
    }

    private void OutFirstController()
    {
        Keybd_event(27, 0, 0, 0);
        Keybd_event(27, 0, 1, 0);
        Keybd_event(27, 0, 2, 0);
    }
    private void Judge()
    {
        Player.GetComponent<FirstPersonController>().enabled = false;
        background.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        tips.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        tips.SetActive(false);
    }
}
