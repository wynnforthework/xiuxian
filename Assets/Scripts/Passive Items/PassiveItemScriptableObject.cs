using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveItemScriptableObject", menuName = "ScriptableObject/Passive Item")]
public class PassiveItemScriptableObject : ScriptableObject
{
    private float multipler;
    public float Multipler
    {
        get => multipler;
        private set => multipler = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
