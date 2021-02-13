using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerNames : MonoBehaviour
{
    public TMP_InputField p1;
    public TMP_InputField p2;
    public TMP_InputField p3;
    public string nextscene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SubmitNames()
    {
        GameManager.Instance.p1name = p1.text;
        GameManager.Instance.p2name = p2.text;
        GameManager.Instance.p3name = p3.text;
        SceneManager.LoadScene(nextscene);
    }
}
