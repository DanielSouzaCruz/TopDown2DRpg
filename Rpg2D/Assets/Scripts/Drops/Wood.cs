using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float woodSpeed;
    [SerializeField] private float timeMove;

    private float timeCount;

    void Start()
    {
        
    }
  
    void Update()
    {
        timeCount += Time.deltaTime;
        
        if(timeCount < timeMove)
        {
            transform.Translate(Vector2.right * woodSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerItems>().Woods++;
            Destroy(gameObject);
        }
    }
}
