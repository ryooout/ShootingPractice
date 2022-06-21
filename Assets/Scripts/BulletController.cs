using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed = 8.0f;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, bulletSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
