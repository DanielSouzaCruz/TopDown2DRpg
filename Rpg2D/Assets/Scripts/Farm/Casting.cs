using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    [SerializeField] private bool playerInTheArea;
    [SerializeField] private int luckyFishing;
    [SerializeField] private GameObject fishPrefab;

    private PlayerItems player;
    private PlayerAnim playerAnim;

    void Start()
    {
        player = FindObjectOfType<PlayerItems>();
        playerAnim = player.GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTheArea && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastStart();
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

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if(randomValue <= luckyFishing)
        {
            Instantiate(fishPrefab, player.transform.position + new Vector3(Random.Range(-2f,-1f),0f,0f), Quaternion.identity);
        }
        else
        {
            
            
        }
    }
}
