using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;

    public int damage = 40;

    public Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = speed * transform.right; //direction
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Enemy hit");
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
