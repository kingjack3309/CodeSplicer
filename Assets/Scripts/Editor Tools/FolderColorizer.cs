using UnityEngine;
using UnityEditor;
using System.IO;

public class FolderColorizer
{
    private static string selectedPath;

    [InitializeOnLoadMethod]
    private static void Initialize()
    {
        EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
    }

    private static void OnProjectWindowItemGUI(string guid, Rect selectionRect)
    {
        // Get the asset path from the GUID
        string path = AssetDatabase.GUIDToAssetPath(guid);

        // Check if it's a folder
        if (AssetDatabase.IsValidFolder(path))
        {
            // Check for Alt+Click
            Event e = Event.current;
            if (e.type == EventType.MouseDown && e.button == 0 && e.alt)
            {
                // Check if the click is within the selection rect
                if (selectionRect.Contains(e.mousePosition))
                {
                    selectedPath = path;

                    // Show the color picker window
                    ColorPickerWindow.ShowWindow(selectedPath);
                    e.Use();
                }
            }

            // Apply the color to the folder icon
            Color folderColor = GetFolderColor(path);
            if (folderColor != Color.white)
            {
                // Draw colored overlay
                Rect colorRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.height, selectionRect.height);
                Color originalColor = GUI.color;
                GUI.color = folderColor;
                GUI.DrawTexture(colorRect, EditorGUIUtility.IconContent("Folder Icon").image);
                GUI.color = originalColor;
            }
        }
    }

    public static Color GetFolderColor(string path)
    {
        // Try to get the color from the folder's meta file
        string metaPath = path + ".meta";
        if (File.Exists(metaPath))
        {
            string[] lines = File.ReadAllLines(metaPath);
            foreach (string line in lines)
            {
                if (line.StartsWith("folderColor:"))
                {
                    string hexColor = line.Substring("folderColor:".Length).Trim();
                    Color color;
                    if (ColorUtility.TryParseHtmlString(hexColor, out color))
                    {
                        return color;
                    }
                }
            }
        }

        return Color.white; // Default color
    }

    public static void SetFolderColor(string path, Color color)
    {
        string metaPath = path + ".meta";
        string hexColor = "#" + ColorUtility.ToHtmlStringRGBA(color);

        if (File.Exists(metaPath))
        {
            // Read existing meta file
            string[] lines = File.ReadAllLines(metaPath);
            bool colorUpdated = false;

            // Update existing color entry or add new one
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("folderColor:"))
                {
                    lines[i] = "folderColor: " + hexColor;
                    colorUpdated = true;
                    break;
                }
            }

            if (!colorUpdated)
            {
                // Add color entry at the end
                string[] newLines = new string[lines.Length + 1];
                System.Array.Copy(lines, newLines, lines.Length);
                newLines[lines.Length] = "folderColor: " + hexColor;
                lines = newLines;
            }

            File.WriteAllLines(metaPath, lines);
        }

        // Refresh the asset database to show the changes
        AssetDatabase.Refresh();
    }
}

// Helper class for the color picker window
public class ColorPickerWindow : EditorWindow
{
    private static string targetPath;
    private Color selectedColor;

    public static void ShowWindow(string path)
    {
        targetPath = path;

        // Get existing color if any
        Color existingColor = FolderColorizer.GetFolderColor(path);

        // Create window
        ColorPickerWindow window = GetWindow<ColorPickerWindow>("Folder Color");
        window.selectedColor = existingColor;
        window.minSize = new Vector2(250, 150);
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Select Folder Color", EditorStyles.boldLabel);

        // Color picker
        selectedColor = EditorGUILayout.ColorField("Color", selectedColor);

        // Hex code field
        string hexCode = "#" + ColorUtility.ToHtmlStringRGBA(selectedColor);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Hex Code");
        hexCode = EditorGUILayout.TextField(hexCode);
        EditorGUILayout.EndHorizontal();

        // Parse hex code if changed
        if (ColorUtility.TryParseHtmlString(hexCode, out Color newColor))
        {
            selectedColor = newColor;
        }

        GUILayout.Space(10);

        // Buttons
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Apply"))
        {
            FolderColorizer.SetFolderColor(targetPath, selectedColor);
            Close();
        }

        if (GUILayout.Button("Reset"))
        {
            FolderColorizer.SetFolderColor(targetPath, Color.white);
            Close();
        }

        if (GUILayout.Button("Cancel"))
        {
            Close();
        }
        EditorGUILayout.EndHorizontal();
    }
}