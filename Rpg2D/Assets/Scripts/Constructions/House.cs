using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Amount")]
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private int woodAmount;
    [SerializeField] float timeAmount;

    [Header("Component")]
    [SerializeField] private bool playerInTheArea;
    [SerializeField] SpriteRenderer houseSprite;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject coli;
    


    private float timeCount;
    private Player player;
    private PlayerAnim playerAnim;
    private PlayerItems playerItems;
    private bool isBeginning;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTheArea && Input.GetKeyDown(KeyCode.E) && playerItems.Woods >= woodAmount)
        {
            isBeginning = true;
            playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = point.position;
            player.isPaused = true;
            playerItems.Woods -= woodAmount;
        }

        if (isBeginning)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= timeAmount)
            {
                playerAnim.OnHammeringEnded();
                houseSprite.color = endColor;
                player.isPaused = false;
                coli.SetActive(true);
            }
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
