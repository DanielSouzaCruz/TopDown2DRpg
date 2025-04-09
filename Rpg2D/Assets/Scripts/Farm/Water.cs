using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private bool playerInTheArea;
    [SerializeField] private int waterValue;

    private PlayerItems player;

    void Start()
    {
        player = FindObjectOfType<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInTheArea && Input.GetKeyDown(KeyCode.E))
        {
            player.WaterMaxLimit(waterValue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInTheArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInTheArea = false;
        }
    }
}
