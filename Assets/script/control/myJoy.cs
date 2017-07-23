using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class myJoy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public enum AxisOption
    {
        // Options for which axes to use
        Both,
        // Use both
        OnlyHorizontal,
        // Only horizontal
        OnlyVertical
        // Only vertical
    }

    public int MovementRange = 100;
    public AxisOption axesToUse = AxisOption.Both;
    // The options for the axes that the still will use
    public string horizontalAxisName = "Horizontal";
    // The name given to the horizontal axis for the cross platform input
    public string verticalAxisName = "Vertical";
    // The name given to the vertical axis for the cross platform input
    public float horizontalValue;
    public float verticalValue;
    public bool m_UseX;
    public bool m_UseY;

    private Vector3 m_StartPos;

    void OnEnable()
    {
    }

    void Start()
    {
        m_StartPos = transform.position;
    }

    void UpdateVirtualAxes(Vector3 value)
    {
        var delta = m_StartPos - value;
        delta.y = -delta.y;
        delta /= MovementRange;
        if (m_UseX)
        {
            this.horizontalValue = -delta.x;
        }

        if (m_UseY)
        {
            this.verticalValue = delta.y;
        }
    }


    public void OnDrag(PointerEventData data)
    {
        Vector3 newPos = Vector3.zero;

        if (m_UseX)
        {
            int delta = (int)(data.position.x - m_StartPos.x);
            delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
            newPos.x = delta;
        }

        if (m_UseY)
        {
            int delta = (int)(data.position.y - m_StartPos.y);
            delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
            newPos.y = delta;
        }
        gameObject.transform.position = new Vector3(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y, m_StartPos.z + newPos.z);
        UpdateVirtualAxes(transform.position);
    }


    public void OnPointerUp(PointerEventData data)
    {
        gameObject.transform.position = m_StartPos;
        UpdateVirtualAxes(m_StartPos);
    }


    public void OnPointerDown(PointerEventData data)
    {
    }
}
