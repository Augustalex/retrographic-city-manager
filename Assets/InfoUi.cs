using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUi : MonoBehaviour
{
    private float _showUntil;
    private string _message;
    private TMP_Text _text;
    
    public void ShowMessage(string message)
    {
        _message = message;
        _showUntil = Time.time + 5;
    }

    void Start()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        if (Time.time < _showUntil)
        {
            _text.text = _message;
        }
        else
        {
            _text.text = "";
        }
    }
}