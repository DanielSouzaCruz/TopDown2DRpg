using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    public DialogueConfig dialogue;
    
    private List<string> sentences = new List<string>();

    bool playerHit;

    void Start()
    {
        NpcSpeakerInfo();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && playerHit)
        {
            DialogueController.instance.Speech(sentences.ToArray());
        }
    }

    void NpcSpeakerInfo()
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++)
        {
            sentences.Add(dialogue.dialogues[i].sentence.portuguese);
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if(hit != null)
        {
            playerHit = true;
        } else
        {
            playerHit = false;
            DialogueController.instance.dialogueObj.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
