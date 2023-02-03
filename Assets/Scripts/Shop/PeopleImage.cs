using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PeopleImage : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
{
    private bool _entered;
    private Vector2 _startPosition, _currentPosition;
    public Vector2 SetRotation;

    public void OnPointerDown(PointerEventData eventData)
    {
        _entered = true;
        _startPosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _entered = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _entered = false;
    }

    private void Update()
    {
        _currentPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (_entered)
        {
            SetRotation = (_currentPosition - _startPosition) / 328f * 180f;
        }
    }
}
