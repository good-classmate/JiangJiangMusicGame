using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
public class FileRead : MonoBehaviour
{
    public Text ShowFile;

    // Start is called before the first frame update
    void Start()
    {
        //SaveInfoByXml();
        ShowFile.text = LoadInfoByXml();
        Debug.Log(ShowFile.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 游戏Xml存档
    /// </summary>
    private void SaveInfoByXml()
    {
        //XmlDocument xmlDoc = new XmlDocument();
        string filePath;
        #if UNITY_ANDROID
            filePath = Application.persistentDataPath + "/" + "infoFile.txt";
        #endif
        #if UNITY_EDITOR
            filePath = Application.dataPath + "/StreamingAssets/infoFile.txt";
        #endif
        //XmlElement root = xmlDoc.CreateElement("Info");

        //XmlElement target;
        //XmlElement modelIndex;
        //XmlElement materialIndex;

        //for (int i = 0; i < info.activeIndex.Count; i++)
        //{
        //    target = xmlDoc.CreateElement("Target");
        //    target.SetAttribute("index", info.activeIndex[i].ToString());
        //    modelIndex = xmlDoc.CreateElement("Model");
        //    modelIndex.InnerText = info.activeModel[i].ToString();
        //    materialIndex = xmlDoc.CreateElement("Material");
        //    materialIndex.InnerText = info.activeMaterialIndex[i].ToString();

        //    target.AppendChild(modelIndex);
        //    target.AppendChild(materialIndex);
        //    root.AppendChild(target);
        //}
        //target = xmlDoc.CreateElement("Score");
        //target.SetAttribute("score", info.score.ToString());
        //root.AppendChild(target);
        //xmlDoc.AppendChild(root);
        //xmlDoc.Save(filePath);
        string[] names = new string[] { "Zara Ali", "Nuha Ali" };
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (string s in names)
            {
                sw.WriteLine(s);

            }
        }
    }
    /// <summary>
    /// 游戏Xml读档
    /// </summary>
    /// <returns></returns>
    private string LoadInfoByXml()
    {
        string filePath;
        #if UNITY_ANDROID
            filePath = Application.persistentDataPath + "/" + "infoFile.txt";
        #endif
        #if UNITY_EDITOR
            filePath = Application.dataPath + "/StreamingAssets/infoFile.txt";
        #endif
        if (File.Exists(filePath))
        {

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(filePath);

            //XmlNodeList targets = xmlDoc.SelectSingleNode("Info").ChildNodes;
            //foreach (XmlElement target in targets)
            //{
            //    if (target.Name == "Target")
            //    {
            //        info.activeIndex.Add(int.Parse(target.GetAttribute("index")));
            //        XmlNode model = target.SelectSingleNode("Model");
            //        info.activeModel.Add(int.Parse(model.InnerText));
            //        XmlNode material = target.SelectSingleNode("Material");
            //        info.activeMaterialIndex.Add(int.Parse(material.InnerText));
            //    }
            //    else if (target.Name == "Score")
            //    {
            //        info.score = int.Parse(target.GetAttribute("score"));
            //    }
            //}
            //return info;
            // 从文件中读取并显示每行
            string txt = "";
            string line = "";
            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    txt += line;
                }
            }
            return txt;
        }
        else
        {
            return null;
        }
    }
}
