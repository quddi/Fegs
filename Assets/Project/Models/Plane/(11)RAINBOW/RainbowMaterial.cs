using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowMaterial : MonoBehaviour
{
    [SerializeField]
    private Renderer rend;
    Color _firstColor, _secondColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        rend.material.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1));
    }
}
