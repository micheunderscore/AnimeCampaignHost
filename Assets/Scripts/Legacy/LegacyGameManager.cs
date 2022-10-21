using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LegacyGameManager : MonoBehaviour {
    [SerializeField] private PlayerManager _playersPanel;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private GameObject _playerPiece, _createForm, _colorForm;

    // TODO: vvv REMOVE DEBUG SYSTEM VARIABLE vvv
    private string[] debug = new string[10];
    void Start() {
        LegacySaveSystem.Initialize();
    }

    void Update() {
        if (Input.GetKeyDown("x")) LegacySaveSystem.ClearSelected();
        if (Input.GetKeyDown("v")) {
            LegacySaveSystem.ClearSelected();
            _createForm.SetActive(true);
            _colorForm.SetActive(false);
        }
        if (Input.GetKeyDown("c")) {
            _colorForm.SetActive(true);
            _createForm.SetActive(false);
        }
        if (Input.GetKeyDown("escape")) {
            _colorForm.SetActive(false);
            _createForm.SetActive(false);
        }

        _playerPiece.SetActive(LegacySaveSystem.Selected != LegacySaveSystem.Empty);
        if (LegacySaveSystem.Selected != LegacySaveSystem.Empty) {
            _playerPiece.GetComponentInChildren<TextMeshProUGUI>().text = LegacySaveSystem.Selected;
        }
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
