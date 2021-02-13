using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayPrompt : MonoBehaviour
{
    public TextAsset locations;
    public TextAsset adjectives;
    public TMP_Text text;
    public GameObject panel;

    void Start()
    {
        string[] locationslist = locations.text.Split('\n');
        string[] adjlist = adjectives.text.Split('\n');
        string cleanedadj = adjlist[Random.Range(0, adjlist.Length)].Replace("\n", "").Replace("\r", "");
        string cleanedloc = locationslist[Random.Range(0, locationslist.Length)].Replace("\n", "").Replace("\r", "");
        text.text = "You are " + cleanedadj + " in " + cleanedloc + ".";
        StartCoroutine(FlashText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FlashText()
    {
        yield return new WaitForSeconds(5);
        text.gameObject.SetActive(false);
        panel.SetActive(false);
    }
}
