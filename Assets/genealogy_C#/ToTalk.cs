using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using SpeechLib;
using NGUI;

namespace Totalk
{
    //与NPC对话的接口
    interface ITalk
    {
        void Speak(GameObject background,GameObject player, UITexture Speaker, UILabel speaktext, GameObject punctuation, string[] talk, int talklenght, int[] firstspeaknum, string speakimage1, string speakimage2,int punt1,int punt2);
        void Change(string str);
        bool EndSpeak();
    }

    class Talk : ITalk
    {
        //public GameObject player;//玩家
        //public Image Speaker;//正在说话的人头像框，用来显示说话人头像
        //public Text speaktext;//对话聊天文本框，用来显示聊天文本
        //public GameObject punctuation;//任务标记点
        //string[] talk，交谈的文本存储在该字符串组中
        //int talklenght，交谈文本的条数
        //int[] firstspeaknum，第一位说话人说话文本的序号
        //string speakimage1，第一位说话人的名称
        //string speakimage2，第二位说话人的名称
        //int pun;是传入参数的物体的标记点的序号,是为了更新标记点

        private int talknum = 0;//聊天的文本序号
        private bool firsttalk = false;//判断是否为第一句聊天内容
        private bool isendtalk = false;//判断是否结束聊天
        //public static int talktime = 0;//聊天的次数，序数，是为了判断玩家第几次聊天，然后根据序数来改变聊天内容

        public void Speak(GameObject background, GameObject player, UITexture Speaker, UILabel speaktext, GameObject punctuation, string[] talk, int talklenght, int[] firstspeaknum, string speakimage1, string speakimage2,int pun1, int pun2)
        {
            player.transform.GetComponent<FirstPersonController>().enabled = false;//用户不能移动

            string speakimage;
            for (int i = 0; i < firstspeaknum.Length; i++)
            {
                if(talknum == firstspeaknum[i])
                {
                    speakimage = speakimage1;
                    Speaker.mainTexture = Resources.Load<Texture>(speakimage);//显示说话人的头像
                    break;//跳出for循环
                }
                else speakimage = speakimage2;    
                Speaker.mainTexture = Resources.Load<Texture>(speakimage);//显示说话人的头像
            }

            speaktext.text = talk[talknum];//显示说话内容

            if (talknum == 0 && firsttalk == false)
            {
                Change(talk[0]);//语音转换,读出第一句，后面的文本需要按下空格键
                firsttalk = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Stop();//可以跳过这一条聊天对话
                talknum++;

                if (talknum >= talklenght)
                {
                    //background.SetActive(false);//聊天背景框消失
                    background.GetComponent<TweenPosition>().PlayReverse();
                    player.transform.GetComponent<FirstPersonController>().enabled = true;

                    punctuation.transform.GetChild(pun1).gameObject.SetActive(false);
                    //在与阎王的聊天结束后，小地图上的戎王所在地的红色标点必须消失
                    punctuation.transform.GetChild(pun2).gameObject.SetActive(true);
                    //下一个任务地点在小地图上显示出来

                    isendtalk = true;//结束聊天
                }
                else Change(talk[talknum]);//语音转换
                
            }
        }

        //将是否结束聊天的信息返回，是为了结束聊天以后关闭触发器
        public bool EndSpeak()
        {
            if (isendtalk == true) return true;
            else return false;
             
        }

        private SpVoice voice = new SpVoice();
        //将文字转换为语音
        public void Change(string str)
        {
            voice.Voice = voice.GetVoices(string.Empty, string.Empty).Item(0);
            voice.Speak(str, SpeechVoiceSpeakFlags.SVSFlagsAsync);
            voice.Rate = 2;//阅读速度

        }
        public void Stop()
        {
            voice.Speak(string.Empty, SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);//停止朗读
        }
    }
}



