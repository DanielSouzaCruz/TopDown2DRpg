using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Talk", menuName = "New Talk/Talk")]
public class DialogueConfig : ScriptableObject
{
    [Header("Config")]
    public GameObject actor;

    [Header("Talk")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string english;
    public string portuguese;
    public string spanish;
}