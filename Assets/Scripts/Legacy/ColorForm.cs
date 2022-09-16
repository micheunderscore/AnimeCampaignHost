using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorForm : MonoBehaviour {
    [SerializeField] private TMP_InputField _inputField;
    public void SaveColor() {
        if (_inputField.text != "") LegacySaveSystem.Color = _inputField.text;
        gameObject.SetActive(false);
        _inputField.text = "";
    }
}
