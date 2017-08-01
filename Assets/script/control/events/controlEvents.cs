using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IControllingEvnets: IEventSystemHandler
{
    void OnSkillRelease(int slot);
}
