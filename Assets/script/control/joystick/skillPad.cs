using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using System.Security.Principal;

public class skillPad : MonoBehaviour
{
    public int slot;
    public skill myPrecious;

    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(this.OnClick);
    }

    void OnClick()
    {
        ExecuteEvents.Execute<IControllingEvnets>(GameObject.Find("role"), null, (x, y) => x.OnSkillRelease(this.slot));
    }

    void Update()
    {
        if (GameObject.Find("coolDownMask" + this.slot.ToString()) != null)
        {
            GameObject go = GameObject.Find("coolDownMask" + this.slot.ToString());
            if (go.GetComponent<Image>() != null)
            {
                try
                {
                    go.GetComponent<Image>().fillAmount = this.myPrecious.coolDownLeft / this.myPrecious.coolDownTime;
                }
                catch (Exception)
                {
                    Debug.Log(go.name);
                }
            }
        }
    }
}
