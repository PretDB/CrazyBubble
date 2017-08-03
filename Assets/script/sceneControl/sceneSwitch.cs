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
        string isFree = GameObject.Find("isFreeMode").GetComponent<Toggle>().isOn.ToString();
        string playerName;
        string skillA = GameObject.Find("LabelA").GetComponent<Text>().text;
        string skillB = GameObject.Find("LabelB").GetComponent<Text>().text;
        string linkTo = GameObject.Find("IPAdd").GetComponent<Text>().text;
        if (GameObject.Find("playerName").GetComponent<Text>().text != "")
        {
            playerName = GameObject.Find("playerName").GetComponent<Text>().text;
        }
        else
        {
            playerName = "defaultName";
        }
        PlayerPrefs.SetString("name", playerName);
        PlayerPrefs.SetString("skillA", skillA);
        PlayerPrefs.SetString("skillB", skillB);
        PlayerPrefs.SetString("free", isFree);
        if (linkTo == "")
        {
            NetworkManager.singleton.StartHost();
            PlayerPrefs.SetString("ImHost", (true).ToString());
        }
        else
        {
            NetworkManager.singleton.networkAddress = linkTo;
            NetworkManager.singleton.StartClient();
            PlayerPrefs.SetString("ImHost", (false).ToString());
        }
    }

}
