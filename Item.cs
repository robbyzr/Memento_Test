using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    private bool inRange;

    [SerializeField] public TextMeshPro TextMeshPro;

    public ItemType itemType;
    public enum ItemType
    {
        FlashLight,
        Laser,
        ZoomOut,
        NPC
    }
    // Start is called before the first frame update
    void Start()
    {
        //menacari script inventori di player
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();   
    }

    // Update is called once per frame
    void Update()
    {
        //jika player dalam range dan mekekan tombol e, maka objek akan masuk ke inventori
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddItem(this);
            gameObject.SetActive(false);
        }
    }

    //mendeteksi player masuk ke area objek
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            TextMeshPro.gameObject.SetActive(true);
        }
    }
    //mendeteksi player keluar dari area objek
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
            TextMeshPro.gameObject.SetActive(false);
        }
    }
}
