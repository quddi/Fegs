using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    private Transform _ThisTransform;
    public PeopleImage InformationOfClick;

    private void Start()
    {
        _ThisTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        _ThisTransform.rotation = Quaternion.Euler(InformationOfClick.SetRotation.y, -InformationOfClick.SetRotation.x, 0);                                                                                                          
    }

    private void GoodRotate()
    {
        _ThisTransform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
