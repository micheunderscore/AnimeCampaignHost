using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem {
    public static string Clear = "EMPTY";
    public static GameData players { get; set; }

    // Cursor Functionality
    public static string Selected { get; set; } = Clear;
    public static void ClearSelected() {
        Selected = Clear;
    }
    // Save Profile
    public static int SelectedProfile { get; set; } = 69420;
    public static bool ShowProfile { get; set; } = false;
    // Color Changer
    public static string Color { get; set; } = Clear;
    public static void ClearColor() {
        Color = Clear;
    }
    public static void Initialize() {
    }

}