using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorForm : MonoBehaviour {
    [SerializeField] private FlexibleColorPicker FCP;
    public void SaveColor() {
        LegacySaveSystem.Color = FCP.color;
        gameObject.SetActive(false);
    }
}
