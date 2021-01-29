using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReadOsu
{
    public class PDArea : MonoBehaviour
    {
        public KeyCode key1;
        private Text ComboText;
        private Text ScoreText;
        public Button clickBtn;
        private bool clickBtnFlag;
        // Start is called before the first frame update
        void Start()
        {
            ComboText = GameObject.Find("Combo").GetComponent<Text>();
            ScoreText = GameObject.Find("Score").GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void mouseDown()
        {
            clickBtnFlag = true;
        }
        public void mouseUp()
        {
            clickBtnFlag = false;
        }
        public void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "note")
            {
                if (Input.GetKeyDown(key1) || clickBtnFlag)
                {
                    Destroy(other.gameObject);
                    ComboText.text = Convert.ToString(Convert.ToInt32(ComboText.text) + 1);
                    if (Convert.ToInt32(ComboText.text) >= 50)
                    {
                        ScoreText.text = Convert.ToString(Convert.ToInt32(ScoreText.text) + 200);
                    }
                    else
                    {
                        ScoreText.text = Convert.ToString(Convert.ToInt32(ScoreText.text) + 100);
                    }
                }
            }
        }

    }
}
