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
        SaveSystem.SelectedProfile = int.Parse(transform.name) - 1;
        SaveSystem.ShowProfile = true;
    }

    public void GetCardNumber() {
        SaveSystem.Selected = transform.name;
    }
}
