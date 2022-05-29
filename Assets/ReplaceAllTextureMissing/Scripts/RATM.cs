#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RATM : EditorWindow
{
    private static bool WinType = false;
    private static List<MeshRenderer> _meshRenderers = new List<MeshRenderer>();
    private Material errorMat;

    [MenuItem("Missing Texture/Tools")]
    static void Setup()
    {
        WinType = true;
        EditorWindow.GetWindow(typeof(RATM));
    }
    
    [MenuItem("Missing Texture/Credit")]
    static void Credit()
    {
        WinType = false;
        EditorWindow.GetWindow(typeof(RATM));
    }

    void ReplaceALlScene()
    {
        try
        {
            errorMat = Resources.Load<Material>("RATM/MissingTexture");
        }
        catch (Exception e)
        {
            Debug.LogError("UNITY CONSOLE : " + e);
            Debug.LogError("RATM CONSOLE (RATMError001) : The resource file containing the folder 'RATM' which contains the material 'MissingTexture.mat' does not exist.");
            throw;
        }

        try
        {
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if (go.scene.IsValid())
                {
                    if (go.GetComponent<MeshRenderer>())
                    {
                        _meshRenderers.Add(go.GetComponent<MeshRenderer>());
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("UNITY CONSOLE : " + e);
            Debug.LogError("RATM CONSOLE (RATMError002) : The content of your scene is empty.");
            Console.WriteLine(e);
            throw;
        }

        try
        {
            for (int i = 0; i < _meshRenderers.Count; i++)
            {
                if (_meshRenderers[i].sharedMaterial == null)
                {
                    _meshRenderers[i].sharedMaterial = errorMat;
                }
                
                var MeshCallMulti = _meshRenderers[i];

                for (int j = 0; j < MeshCallMulti.sharedMaterials.Length; j++)
                {
                    if (MeshCallMulti.sharedMaterials[j] == null)
                    {
                        MeshCallMulti.sharedMaterials[j] = errorMat;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("UNITY CONSOLE : " + e);
            Debug.LogError("RATM CONSOLE (RATMError003) : The selected objects do not exist, or have not been instantiated, or even worse Unity cannot modify the materials found.");
            throw;
        }
    }
    
    
    void OnGUI()
    {
        try
        {
            if (WinType)
            {
                GUILayout.Space(5.0f);
                GUILayout.Label ("Menu", EditorStyles.centeredGreyMiniLabel);
                GUILayout.Space(10.0f);
            
                if (GUILayout.Button("Replace All Texture Missing in Scene"))
                {
                    ReplaceALlScene();
                }

                GUILayout.Space(10.0f);
                GUILayout.Label ("© 2016 - 2022 Furrany Studio", EditorStyles.centeredGreyMiniLabel);
            }
            else
            {
                GUILayout.Space(5.0f);
                GUILayout.Label ("Crédit", EditorStyles.centeredGreyMiniLabel);
                GUILayout.Space(10.0f);
            
                if (GUILayout.Button("Ko-Fi"))
                {
                    Application.OpenURL("https://ko-fi.com/maxime66410");
                }
            
                if (GUILayout.Button("Gumroad"))
                {
                    Application.OpenURL("https://furranystudio.gumroad.com/");
                }

                if (GUILayout.Button("Furrany Studio"))
                {
                    Application.OpenURL("https://furranystudio.fr/");
                }
            
                if (GUILayout.Button("Unity Assets Store : Furrany Studio"))
                {
                    Application.OpenURL("https://assetstore.unity.com/publishers/50575");
                }
            
                GUILayout.Space(10.0f);
            
                GUILayout.Label ("© 2016 - 2022 Furrany Studio", EditorStyles.centeredGreyMiniLabel);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("UNITY CONSOLE : " + e);
            Debug.LogError("RATM CONSOLE (RATMError004) : Window for RATM can't open.");
            throw;
        }
    }
    
    
}
#endif