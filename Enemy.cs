using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int health = 2;
    [SerializeField] private int damage = 1;

    private float hitCooldown = 1f; 
    private float lastHitTime;

    private GameObject player;
    
    private bool hasLineOfSight = false;

    Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        initialPosition = transform.position;
        lastHitTime = -hitCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        //kejar player jika berada di hadapan enemy
        if (hasLineOfSight)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
       
    }

    private void FixedUpdate()
    {

        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if(ray.collider != null)
        {
            hasLineOfSight = ray.collider.CompareTag("Player");
            if(hasLineOfSight)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else 
            {
                //jika tidak ada player kembali ke posisi awal
                StartCoroutine(BackToPosition());

                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }
    
    //kembali ke posisi awal
    IEnumerator BackToPosition ()
    {
        yield return new WaitForSeconds(5f);   
        transform.position = Vector2.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null && Time.time >= lastHitTime + hitCooldown)
        {
            player.TakeDamage(damage);
            lastHitTime = Time.time; 
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    

}
