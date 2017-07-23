using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;

public class geographicalLimit : MonoBehaviour
{
    public Rect activeArea;
    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    public bool IsInActiveArea(Vector3 position)
    {
        return this.activeArea.Contains(position);
    }

}
