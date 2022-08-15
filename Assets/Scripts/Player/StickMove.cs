using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickMove : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private float _sensitivity;

    private Vector2 _position;
    private Vector2 _startPosition;
    private Vector2 _tempVector2;

    public Vector2 Position => ClampVector2(_position * -_sensitivity);

    private Vector2 ClampVector2(Vector2 Vector)
    {
        return new Vector2(Mathf.Clamp(Vector.x, -1, 1), Mathf.Clamp(Vector.y, -1, 1));
    }
    public void OnDrag(PointerEventData eventData)
    {
        var point = Camera.main.ScreenToViewportPoint(eventData.position);
        _tempVector2.x = point.x;
        _tempVector2.y = point.y;
        _position =  _startPosition - _tempVector2;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        var point = Camera.main.ScreenToViewportPoint(eventData.position);
        _tempVector2.x = point.x;
        _tempVector2.y = point.y;
        _startPosition = _tempVector2;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _position = Vector3.zero;
    }
}
