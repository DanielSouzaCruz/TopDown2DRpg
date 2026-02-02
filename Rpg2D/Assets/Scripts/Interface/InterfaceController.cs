using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image woodUIBar;

    private PlayerItems playerItems;

    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.WaterLimit;
        woodUIBar.fillAmount = playerItems.Woods / playerItems.WoodLimit;
        carrotUIBar.fillAmount = playerItems.carrots / playerItems.CarrotsLimit;
    }
}
