using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationsModifier : MonoBehaviour
{
    [SerializeField]
    private  Transform[] _peoples, _platforms, _bonuses;

    public void ResetAllRotations()
    {
        ResetRotationOf(_peoples);
        ResetRotationOf(_platforms);
        ResetRotationOf(_bonuses);
    }

    private void ResetRotationOf(Transform[] Objects)
    {
        foreach(Transform item in Objects)
        {
            item.rotation = Quaternion.identity;
        }
    }
}
