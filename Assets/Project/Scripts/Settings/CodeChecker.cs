using System.Collections.Generic;
using System;
using UnityEngine;

public class CodeChecker : MonoBehaviour
{
    [SerializeField]
    private TextAsset inputText;
    private Dictionary<string, DateTime> codesAndDatesD = new Dictionary<string, DateTime>();

    private void Start()
    {
        foreach (string item in inputText.text.Split(new char[] { '\n' }))
        {
            
            string[] pair = item.Split();
            Debug.Log(pair[0] + " " + pair[1]);
            codesAndDatesD.Add(pair[0], DateTime.Parse(pair[1]));
        }
    }

    public bool codeIsAvaliableAndActive(string code)
    {
        return codesAndDatesD.ContainsKey(code) && codesAndDatesD[code] > DateTime.Now;
    }
}
