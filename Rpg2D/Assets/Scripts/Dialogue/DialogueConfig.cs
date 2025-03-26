using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueConfig))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueConfig dc = (DialogueConfig)target;

        Languages lg = new Languages();
        lg.portuguese = dc.sentence;

        Sentences st = new Sentences();
        st.profile = dc.speakerSprite;
        st.sentence = lg;

        if(GUILayout.Button("Create Dialogue"))
        {
            if(dc.sentence != "")
            {
                dc.dialogues.Add(st);
                dc.speakerSprite = null;
                dc.sentence = "";
            }
        }
    }
}


#endif