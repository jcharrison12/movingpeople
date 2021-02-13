using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public bool go;
    public float timer = 120;
    public TMP_Text timertext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (go)
        //{
        //    if (timer > 0)
        //    {
        //        timer = -Time.deltaTime;
        //        timertext.text = Mathf.FloorToInt(timer).ToString();
        //    }
        //}
    }
}
