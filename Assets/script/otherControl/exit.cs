using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class exit : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(this.OnClick);
    }


    void OnClick()
    {
        NetworkManager.singleton.StopHost();
//        GameObject.Find("GodIsLookingAtYou").GetComponent<NetworkManager>().StopHost();
//        SceneManager.LoadScene("offline");
//        SceneManager.SetActiveScene(SceneManager.GetSceneByName("offline"));
//        SceneManager.UnloadSceneAsync("1");
    }
}
