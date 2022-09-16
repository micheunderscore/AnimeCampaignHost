using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HurtHeal : MonoBehaviour {
    [SerializeField] private TMP_InputField _healthAmt;
    [SerializeField] private GameObject[] _stats;
    private int amount;

    public void Start() {
        for (int i = 0; i < _stats.Length; i++) {
            _stats[i].GetComponent<Button>().onClick.AddListener(delegate { UpdateValue(i); });
        }
    }

    public void Update() {
        var txtAmt = _healthAmt.text;
        bool parsed = int.TryParse(txtAmt, NumberStyles.Integer, CultureInfo.InvariantCulture, out int amtOut);
        amount = (txtAmt.Length > 0 && txtAmt.Length < 11) && parsed ? amtOut : 0;
    }

    public void UpdateValue(int which) {
        var whichStat = _stats[which];

        int currAmt = whichStat.GetComponent<StatBar>().amt;
        int maxAmt = whichStat.GetComponent<StatBar>().max;

        int posAmt = (currAmt + amount <= maxAmt) ? amount : maxAmt - currAmt;
        int negAmt = (currAmt + amount >= 0) ? amount : -currAmt;

        whichStat.GetComponent<StatBar>().amt += amount >= 0 ? posAmt : negAmt;
        _healthAmt.text = "";
    }
}
