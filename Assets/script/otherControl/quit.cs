using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quit : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(this.OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        Application.Quit();
    }
}
