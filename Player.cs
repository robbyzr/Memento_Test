using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 3;
    
    [SerializeField] private float speed;

    [SerializeField] private FieldOfView fieldOfView;
  
    private Rigidbody2D rb;
    public bool playerDead = false;

    [SerializeField] private Camera cam;


   
    Vector2 movement;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //untuk mendeteksi input dari player
       float moveX = Input.GetAxisRaw("Horizontal");
       float moveY = Input.GetAxisRaw("Vertical");

       movement = new Vector2(moveX, moveY).normalized;

       //untuk mendeteksi kursor 
       mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //menggerakan player berdasarkan inputan
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        
        //player menghadap gerak kursor
        Vector2 lookDir = mousePos - rb.position;

        //FieldOfView mengikuti arah gerak mouse/aim
        fieldOfView.SetAimDirection(lookDir);
        fieldOfView.SetOrigin(transform.position);

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void TakeDamage(int damage)
    {
        
        health -= damage;
        Debug.Log("hit");
        if (health <= 0)
        {
            playerDead = true;
        }
    }

}
