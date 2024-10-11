using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    public GameObject losePanel;
    public GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        Inventory inventory = player.GetComponent<Inventory>();
        if (player.playerDead == true)
        {
            losePanel.SetActive(true);
            Paused();
        }
        if(inventory != null && inventory.npcAdded == true)
        {
            endPanel.SetActive(true);
            Paused();
        }
        

    }
    public void Paused()
    {
        Time.timeScale = 0.0f;
    }
}
