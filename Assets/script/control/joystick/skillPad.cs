using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class skillPad : MonoBehaviour
{
    public skill seeMyPrecious;

    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(this.OnClick);
        if (seeMyPrecious == null)
        {
            this.seeMyPrecious = GameObject.FindWithTag("player").GetComponent<player>().skillSlot[0];
            this.seeMyPrecious.allowToCoolDown = true;
            this.seeMyPrecious.avaliable = true;
            this.seeMyPrecious.coolDownTime = 1f;
        }
    }

    void OnClick()
    {
        this.seeMyPrecious.ReleaseSkill();
        Debug.Log("see me precious");
    }

}
