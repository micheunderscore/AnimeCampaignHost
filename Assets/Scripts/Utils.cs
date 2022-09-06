using System.IO;
using UnityEngine;

public class JsonReader {
    public string Read(string route) {
        string filePath = Path.Combine(Application.streamingAssetsPath + Path.DirectorySeparatorChar, route);
        string jsonString = "";

        Debug.Log("JSONREADER >> " + System.Environment.NewLine + filePath);

#if UNITY_EDITOR || UNITY_IOS
        jsonString = File.ReadAllText(filePath);

#elif UNITY_ANDROID
        WWW reader = new WWW (filePath);
        while (!reader.isDone) {
        }
        jsonString = reader.text;
#endif

        Debug.Log("JSONREADER >> Data loaded, dictionary contains: " + jsonString);

        return (jsonString);
    }

    public void Write(string route, GameData saveData) {
        string filePath = Path.Combine(Application.streamingAssetsPath + Path.DirectorySeparatorChar, route);

        string jsonString = JsonUtility.ToJson(saveData);
        File.WriteAllText(filePath, jsonString);
    }
}

// Class type declarations. Globally accessible.