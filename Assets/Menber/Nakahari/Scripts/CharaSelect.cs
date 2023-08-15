using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaSelect : MonoBehaviour
{
    public InputActionAsset actionAsset;

    // キャラタイプごとに対応したActionMapを格納するDictionary
    private Dictionary<Type.CharacterType, InputActionMap> characterActionMaps = new Dictionary<Type.CharacterType, InputActionMap>();

    private void MCreateCharActionMap()
    {
        foreach (Type.CharacterType charType in Enum.GetValues(typeof(Type.CharacterType)))
        {
            string actionMapName = charType.ToString();
            var actionMap = actionAsset.FindActionMap(actionMapName);
            if (actionMap != null)
            {
                characterActionMaps.Add(charType, actionMap);
            }
        }
    }
    public Dictionary<Type.CharacterType, InputActionMap> CharacterActionMaps => characterActionMaps;

    private void Start()
    {
        MCreateCharActionMap();
    }
}
