using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour {
    [SerializeField] private PlayerCard _playerCard;
    [SerializeField] private Color playerColor, npcColor, enemyColor;
    private JsonReader jsonReader = new JsonReader();
    private GridLayoutGroup playerCards;

    public void Start() {
        string jsonString = jsonReader.Read("players.json");
        LegacySaveSystem.players = JsonUtility.FromJson<GameData>(jsonString);

        LoadChars();
    }

    public void LoadChars() {
        GameData players = LegacySaveSystem.players;

        int j = 1;

        foreach (Piece piece in players.pieces) {
            // if (piece.name == "class1a") continue; // TODO: Improve this (more dynamic)
            for (int i = 0; i < piece.characters.Length; i++) {
                var cCard = Instantiate(_playerCard, Vector3.zero, Quaternion.identity, transform);
                var cProfile = piece.characters[i];

                switch (piece.name) {
                    case "enemies":
                        cCard.GetComponent<Image>().color = enemyColor;
                        break;
                    case "npc":
                        cCard.GetComponent<Image>().color = npcColor;
                        break;
                    default:
                        cCard.GetComponent<Image>().color = playerColor;
                        break;
                }

                cCard.name = $"0{j}";

                foreach (Transform t in cCard.transform) {
                    if (t.name == "PName") t.GetComponent<TextMeshProUGUI>().text = cProfile.name;
                    if (t.name == "MOV") t.GetComponent<TextMeshProUGUI>().text = $"{cProfile.stats.mov}";
                    if (t.name == "PRO") {
                        t.GetComponent<StatBar>().amt = cProfile.stats.pro;
                    }
                    if (t.name == "STA") {
                        t.GetComponent<StatBar>().amt = cProfile.stats.sta;
                        t.GetComponent<StatBar>().max = cProfile.stats.sta;
                    }
                    if (t.name == "pSTA") {
                        t.GetComponent<StatBar>().amt = 0;
                        t.GetComponent<StatBar>().max = cProfile.stats.sta;
                    }
                }
                j++;
            }
        }
    }
}
