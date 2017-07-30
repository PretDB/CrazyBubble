using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Reflection;

public class myJoy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IControllingEvnets
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

        int deltaX = (int)(data.position.x - m_StartPos.x);
        deltaX = Mathf.Clamp(deltaX, -MovementRange, MovementRange);
        newPos.x = deltaX;

        int deltaY = (int)(data.position.y - m_StartPos.y);
        deltaY = Mathf.Clamp(deltaY, -MovementRange, MovementRange);
        newPos.y = deltaY;


        RectTransform parentTransform = this.gameObject.GetComponentInParent<RectTransform>();
        float angle = Mathf.Atan(newPos.y / newPos.x);
        float maxX = parentTransform.rect.width;
        float maxY = parentTransform.rect.height;

        float maxLength = Mathf.Sqrt(Mathf.Pow(maxX * Mathf.Cos(angle), 2) + Mathf.Pow(maxY * Mathf.Sin(angle), 2));
        newPos = Vector3.ClampMagnitude(newPos, maxLength);
        gameObject.transform.position = new Vector3(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y, m_StartPos.z + newPos.z);
        UpdateVirtualAxes(transform.position);
        ExecuteEvents.Execute<IControllingEvnets>(this.gameObject, null, );
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
