using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageFinishEvent : MonoBehaviour
{
    [SerializeField]
    private Animator _messageAnimator;
     
    public void FinishAnimation()
    {
        _messageAnimator.SetBool("IsAnimating", false);
    }
}
