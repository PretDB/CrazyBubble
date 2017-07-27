using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weightIndicator : MonoBehaviour
{

    private GUIStyle healthStyle;
    private GUIStyle backStyle;
    private physic combat;

    void Awake()
    {
        combat = this.gameObject.GetComponent<physic>();
    }

    void OnGUI()
    {
        InitStyles();

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        GUI.color = Color.green;
        GUI.backgroundColor = Color.green;
        GUI.TextField(new Rect(pos.x - 15, Screen.height - pos.y + 15, 35, 30), string.Format("{0:F2}", this.combat.weight));
    }

    void InitStyles()
    {
        if (healthStyle == null)
        {
            healthStyle = new GUIStyle(GUI.skin.box);
            healthStyle.normal.background = MakeTex(2, 2, new Color(0f, 1f, 0f, 1.0f));
        }

        if (backStyle == null)
        {
            backStyle = new GUIStyle(GUI.skin.box);
            backStyle.normal.background = MakeTex(2, 2, new Color(0f, 0f, 0f, 1.0f));
        }
    }

    Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
