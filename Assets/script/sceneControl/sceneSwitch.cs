using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Sockets;
using UnityEngine.Networking;
using System.Reflection.Emit;

public class sceneSwitch : MonoBehaviour
{
    void OnEnable()
    {
    }

    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(this.OnClick);
    }

    void OnClick()
    {
        string a;
        string skillA = GameObject.Find("LabelA").GetComponent<Text>().text;
        string skillB = GameObject.Find("LabelB").GetComponent<Text>().text;
        if (GameObject.Find("playerName").GetComponent<Text>().text != "")
        {
            a = GameObject.Find("playerName").GetComponent<Text>().text;
        }
        else
        {
            a = "defaultName";
        }
        PlayerPrefs.SetString("name", a);
        PlayerPrefs.SetString("skillA", skillA);
        PlayerPrefs.SetString("skillB", skillB);
        NetworkManager.singleton.StartHost();
        Debug.Log(skillA);
    }

}
