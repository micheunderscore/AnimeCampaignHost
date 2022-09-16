using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatBar : MonoBehaviour {
    [SerializeField] private RectTransform barFill;
    [SerializeField] private TextMeshProUGUI barLabel;
    [SerializeField] public int amt = 0, max = 100;

    public void Update() {
        barFill.localScale = new Vector3((((float)amt / (float)max)), barFill.localScale.y, barFill.localScale.z);
        barLabel.GetComponent<TextMeshProUGUI>().text = $"{amt}/{max}";
    }
}
