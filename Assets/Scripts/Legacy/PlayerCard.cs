using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerCard : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI cardNumber;

    public void Update() {
        cardNumber.text = transform.name;
    }

    public void CheckProfiles() {
        LegacySaveSystem.SelectedProfile = int.Parse(transform.name) - 1;
        LegacySaveSystem.ShowProfile = true;
    }

    public void GetCardNumber() {
        LegacySaveSystem.Selected = transform.name;
    }
}
