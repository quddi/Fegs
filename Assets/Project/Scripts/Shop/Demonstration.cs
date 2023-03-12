using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonstration : MonoBehaviour
{
    public RotationsModifier ProductDemonstration;
    public PeopleImage TouchTaker;

    public void ResetRotation()
    {
        ProductDemonstration.ResetAllRotations();
        TouchTaker.SetRotation = Vector3.zero;
    }
}
