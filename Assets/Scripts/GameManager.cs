using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField] private PlayerManager _playersPanel;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private GameObject _playerPiece, _createForm, _colorForm;

    // vvv DEBUG STUFF REMEMBER TO REMOVE vvv
    private string[] debug = new string[10];
    void Start() {
        SaveSystem.Initialize();
    }

    void Update() {
        // debug[0] = $"GAME MANAGER >> {SaveSystem.Selected}";

        if (Input.GetKeyDown("x")) SaveSystem.ClearSelected();
        // if (Input.GetKeyDown("c")) {
        //     SaveSystem.ClearSelected();
        //     _createForm.SetActive(true);
        // }
        if (Input.GetKeyDown("c")) {
            _colorForm.SetActive(true);
        }
        if (Input.GetKeyDown("escape")) {
            _createForm.SetActive(false);
        }

        _playerPiece.SetActive(SaveSystem.Selected != SaveSystem.Clear);
        if (SaveSystem.Selected != SaveSystem.Clear) {
            _playerPiece.GetComponentInChildren<TextMeshProUGUI>().text = SaveSystem.Selected;
        }
        // _profileDisplay.SetActive(SaveSystem.ShowProfile);
    }

    // void OnGUI() {
    //     GUI.Label(
    //         new Rect(
    //             5,                       // x, left offset
    //             0,                       // y, bottom offset
    //             300f,                    // width
    //             150f                     // height
    //         ),
    //         string.Join("\n", debug),    // the display text
    //         GUI.skin.textArea            // use a multi-line text area
    //     );
    // }
}
