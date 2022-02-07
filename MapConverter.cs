using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapConverter : EditorWindow
{
    string myString = " ";
    Texture2D mapTexture;
    Color32 player = Color.red;
    string playerInt = "0x01";
    Color32 enemys = Color.blue;
    string enemysInt = "0x02";
    Color32 end = Color.green;
    string endInt = "0x03";
    Color32 spikes = Color.cyan;
    string spikesInt = "0x04";
    Color32 walls = Color.black;
    string wallsInt = "0x05";

    [MenuItem("Window/MapGenerator")]
    public static void ShowWindow() {
        EditorWindow.GetWindow<MapConverter>("Convert png to map");
    }
    private void OnGUI()
    {
        GUILayout.Label("MAP CONVERTER", EditorStyles.boldLabel);
        GUILayout.Label("Settings", EditorStyles.boldLabel);

        GUILayout.Label("player");
        player = EditorGUILayout.ColorField(player,GUILayout.MaxWidth(50f));
        GUILayout.Label("enemy");
        enemys = EditorGUILayout.ColorField(enemys, GUILayout.MaxWidth(50f));
        GUILayout.Label("end");
        end = EditorGUILayout.ColorField(end, GUILayout.MaxWidth(50f));
        GUILayout.Label("spikes");
        spikes = EditorGUILayout.ColorField(spikes, GUILayout.MaxWidth(50f));
        GUILayout.Label("walls");
        walls = EditorGUILayout.ColorField(walls, GUILayout.MaxWidth(50f));
        
        
        EditorGUILayout.BeginHorizontal("box");
        mapTexture = (Texture2D)EditorGUILayout.ObjectField(mapTexture, typeof(Texture2D), false,GUILayout.MaxWidth(250f));

        if (GUILayout.Button("Convertir",GUILayout.MaxWidth(80f))) {
            Convert(mapTexture);
        }
        EditorGUILayout.EndHorizontal();
        myString = EditorGUILayout.TextField("Output", myString,GUILayout.MinHeight(500f),GUILayout.MinWidth(500f));
    }

    private void Convert(Texture2D image) {
        myString = "";
        for (int y = 0; y < image.height; y++) {

            myString += "{";
            for (int x = 0; x < image.width; x++) {
                Color32 c = image.GetPixel(x, y);


                c.a = 255;

                if (c.Equals(player)) myString += playerInt;
                else if (c.Equals(enemys)) myString += enemysInt;
                else if (c.Equals(spikes)) myString += spikesInt;
                else if (c.Equals(end)) myString += endInt;
                else if (c.Equals(walls)) myString += wallsInt;
                else
                {
                    myString += "0x32";
                }
                if((image.width - x) != 1)myString += ",";
            }
            if ((image.height - y) != 1) myString += "},\n";
            else myString += "}\n";
        }
    }
}
