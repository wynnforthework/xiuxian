using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveItemScriptableObject", menuName = "ScriptableObject/Passive Item")]
public class PassiveItemScriptableObject : ScriptableObject
{
    [SerializeField]
    private float multipler;
    public float Multipler
    {
        get => multipler;
        private set => multipler = value;
    }

    [SerializeField]
    int level;

    public int Level
    {
        get => level;
        private set => level = value;
    }

    [SerializeField]
    GameObject nextLevelPrefab;

    public GameObject NextLevelPrefab
    {
        get => nextLevelPrefab;
        private set => nextLevelPrefab = value;
    }
    
    public string Name
    {
        get => name;
        private set => name = value;
    }

    [SerializeField]
    private string description;

    public string Description
    {
        get => description;
        private set => description = value;
    }

    [SerializeField]
    Sprite icon;

    public Sprite Icon
    {
        get => icon;
        private set => icon = value;
    }
}
