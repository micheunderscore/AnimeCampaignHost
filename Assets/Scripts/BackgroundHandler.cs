using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundHandler : MonoBehaviour {
    [SerializeField] private Image bgImage;
    [SerializeField] private Sprite[] images;
    [SerializeField] private int curr = 0;

    private KeyCode[] numKeyCodes = {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };

    private KeyCode[] arrowKeyCodes = {
        KeyCode.RightBracket,
        KeyCode.LeftBracket,
    };

    public void Update() {
        CycleImages();
    }

    public void CycleImages() {
        for (int i = 0; i < Mathf.Clamp(images.Length, images.Length, numKeyCodes.Length); i++) {
            if (Input.GetKeyDown(numKeyCodes[i]))
                curr = i;
            bgImage.sprite = images[curr];
        }
        if (Input.GetKeyDown(KeyCode.RightBracket) && images.Length > 0) {
            if (curr == images.Length - 1) { curr = 0; } else { curr++; }
            bgImage.sprite = images[curr];
        } else if (Input.GetKeyDown(KeyCode.LeftBracket) && images.Length > 0) {
            if (curr == 0) { curr = images.Length - 1; } else { curr--; }
            bgImage.sprite = images[curr];
        }
    }

    public void SetInImageArray(int index, Sprite image) {
        images[index] = image;
    }
}
