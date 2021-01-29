using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    private Text ComboText;
    // Start is called before the first frame update
    void Start()
    {
        ComboText = GameObject.Find("Combo").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        ComboText.text = "0";

    }
}
