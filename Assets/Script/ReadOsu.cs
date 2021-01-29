using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace ReadOsu
{
    public class ReadOsu
    {
        private StringReader fileContent;
        public ReadOsu(string filePath)
        {
            //fileContent = new StreamReader(filePath);

#pragma warning disable CS0618 // 类型或成员已过时
            UnityEngine.WWW www = new WWW(Application.dataPath + "/" + filePath);
            Debug.Log(Application.dataPath + "/" + filePath);
#pragma warning restore CS0618 // 类型或成员已过时
            //yield return www;
            if (www != null && string.IsNullOrEmpty(www.error))
            {
                while (!www.isDone) { }
                //fileContent = new StreamReader(new MemoryStream(Encoding.Unicode.GetBytes(www.text)));
                fileContent = new  StringReader(www.text);
            }           
            www.Dispose();
        }
        public List<String> getSectionContent(string sectionName)
        {
            List<String> sectionContentList = new List<string>();
            while ( fileContent.Peek() > -1)//!fileContent.EndOfStream)
            {
                String oneLine = fileContent.ReadLine();
                if (oneLine == null || oneLine == "") continue;
                if (oneLine[0] == '[')
                {
                    if (oneLine[oneLine.Length - 1] == ']')
                    {
                        if (oneLine.IndexOf(sectionName) == -1) continue;
                        oneLine = fileContent.ReadLine();
                        if (oneLine == null || oneLine == "") continue;
                        while (true)
                        {
                            sectionContentList.Add(oneLine);
                            oneLine = fileContent.ReadLine();
                            if (oneLine == null || oneLine == "") break;
                        }
                        break;
                    }
                }
            }
            if (sectionContentList.Count == 0) sectionContentList.Add("NotFoundSection");
            return sectionContentList;
        }
        public List<HitObjects> transformHitObjects(List<String> HitObjectsData)
        {
            List<HitObjects> HitObjectsList = new List<HitObjects>();           
            foreach(String oneHitObjectsData in HitObjectsData)
            {
                //Debug.Log(oneHitObjectsData);
                HitObjects hitObjects = new HitObjects();
                string[] objectParams = oneHitObjectsData.Split(',');
                if(Convert.ToInt32(objectParams[0]) == 64)   hitObjects.X = 0;
                if(Convert.ToInt32(objectParams[0]) == 192)  hitObjects.X = 1;
                if(Convert.ToInt32(objectParams[0]) == 320) hitObjects.X = 2;
                if(Convert.ToInt32(objectParams[0]) == 448) hitObjects.X = 3;
                hitObjects.Y = Convert.ToInt32(objectParams[1]);
                hitObjects.time = Convert.ToInt32(objectParams[2]);
                hitObjects.type = Convert.ToInt32(objectParams[3]);
                hitObjects.hitSound = Convert.ToInt32(objectParams[4]);
                hitObjects.defalt = objectParams[5];
                HitObjectsList.Add(hitObjects);
            }
            return HitObjectsList;
            
        }
        ~ReadOsu()
        {
            fileContent.Close();
        }
    }
}
