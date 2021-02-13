using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharadesPrompt : MonoBehaviour
{
    public TextAsset prompts;
    public TMP_Text stopplayer;
    public TMP_Text text;
    public TMP_Text _continue;
    public GameObject button1;
    public GameObject button2;
    public GameObject startbutton;
    public Canvas canvas;
    public bool go;
    public float timer = 120f;
    public TMP_Text timertext;
    public TMP_Text timesup;
    public GameObject restart;

    // Start is called before the first frame update
    void Start()
    {
        _continue.gameObject.SetActive(false);
        button2.SetActive(false);
        startbutton.SetActive(false);
        timesup.gameObject.SetActive(false);
        restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (go == true)
        {
            if (timer > 0 && !Input.GetKeyDown("space"))
            {
                timer -= Time.deltaTime;
                timertext.text = Mathf.FloorToInt(timer).ToString();
            }
            else if (Input.GetKeyDown("space") || timer <= 0)
            {
                timesup.gameObject.SetActive(true);
                restart.SetActive(true);
                Debug.Log("test if space is pressed");
            }
        }

    }
    public void ContinueNext()
    {
        text.gameObject.SetActive(false);
        _continue.gameObject.SetActive(true);
        stopplayer.gameObject.SetActive(false);
        button2.SetActive(false);
        _continue.text = "Please resume screen sharing.";
        startbutton.SetActive(true);
    }
    public void ShowPrompt()
    {
        string[] promptlist = prompts.text.Split('\n');
        string cleaned = promptlist[Random.Range(0, promptlist.Length)].Replace("\n", "").Replace("\r", "");
        text.text = "You are " + cleaned + ".";
        button1.SetActive(false);
        button2.SetActive(true);
    }
    public void StartGame()
    {
        canvas.gameObject.SetActive(false);
        go = true;
    }
}
