using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace ReadOsu
{

    public class GM : MonoBehaviour
    {
        List<HitObjects> hitObjectsList;
        private AudioClip video;
        private AudioSource music;
        public GameObject Key;
        private string musicPath;
        private string osuPath;
        private StreamReader info;
        private string str;
        private int frameNum = 0;
        private int dataIndex = 0;
        private bool musicPlayFlag = false;
        JsonData infoData;

        public Text text1;
        public Text text2;
        public Text text3;
        public Text text4;
        // Start is called before the first frame update
        void Start()
        {
            #if UNITY_EDITOR
                string filepath = Application.dataPath + "/StreamingAssets";
            #elif UNITY_IPHONE
                string filepath = Application.dataPath +"/Raw";
            #elif UNITY_ANDROID
                string filepath =Application.streamingAssetsPath;
            #endif

            //info = new StreamReader(Application.dataPath + "/info.json");
            text1.text = filepath + "/info.txt";


#pragma warning disable CS0618 // 类型或成员已过时
            WWW www = new WWW(filepath + "/info.txt");
            Debug.Log(filepath + "/info.json");
#pragma warning restore CS0618 // 类型或成员已过时
            //yield return www;
            if (www != null && string.IsNullOrEmpty(www.error))
            {
                str = www.text;
            }
            while (!www.isDone) { }
            www.Dispose();

            //str = info.ReadToEnd();
            byte[] array = System.Text.Encoding.Default.GetBytes(str);
            infoData = JsonMapper.ToObject(System.Text.Encoding.UTF8.GetString(array));
            musicPath = infoData["GouZhiQiShi"]["musicPath"].ToString();
            osuPath = infoData["GouZhiQiShi"]["oszPath"].ToString();
            ReadOsu readOsu = new ReadOsu(osuPath);
            List<String> sectionList = readOsu.getSectionContent("HitObjects");
            hitObjectsList = readOsu.transformHitObjects(sectionList);
            video = Resources.Load<AudioClip>(musicPath);
            music = gameObject.AddComponent<AudioSource>();
            music.playOnAwake = true;
            music.clip = video;
            text4.text = osuPath;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        private void FixedUpdate()
        {
            if(frameNum > hitObjectsList[dataIndex].time)
            {
                Instantiate(Key, new Vector3(-2.18f + 1.5f * hitObjectsList[dataIndex].X, 4.84f, 3.6f), new Quaternion(0.707F, 0 ,0, 0.707F));
                dataIndex++;
            }
            frameNum++;
            if (frameNum >= 1000 && musicPlayFlag == false)
            {
                music.Play();
                musicPlayFlag = true;
            }
        }
    }
}
