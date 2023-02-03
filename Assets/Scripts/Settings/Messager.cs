using UnityEngine;
using UnityEngine.UI;

public class Messager : MonoBehaviour
{
    private Animator _animator;
    private Text _message;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _message = GetComponentInChildren<Text>();
    }

    public void ShowMessage(string message)
    {
        if (message == null || message == "")
            throw new System.InvalidOperationException();

        _message.text = message;
        _animator.SetBool("GiveMessage", true);
    }

    public void FinishAnimation()
    {
        _animator.SetBool("GiveMessage", false);
    }
}
