using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(this.OnClick);
    }

    void OnClick()
    {
//        GameObject.Find("mySole").GetComponent<mySole>().myName = GameObject.Find("nameHere").GetComponent<InputField>().text;
        SceneManager.LoadScene("1", LoadSceneMode.Additive);
        Scene scene1 = SceneManager.GetSceneByName("1");
        SceneManager.MoveGameObjectToScene(GameObject.Find("mySole"), scene1);
        Debug.LogError("set active scene falt    " + SceneManager.SetActiveScene(scene1).ToString());
        SceneManager.UnloadSceneAsync("offline");
    }
}
