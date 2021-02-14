using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sp;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude<2f)
        {
            Vector3 dir = new Vector3(180, 0, 0);
            transform.localRotation = Quaternion.Euler(dir);
            sp.sortingOrder = 2;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver() ;
            Destroy(this.gameObject);
        }
    }
}
