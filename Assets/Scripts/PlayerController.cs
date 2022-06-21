using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    public GameObject bullet;
    public GameObject firePos;
    /// <summary>  弾の間の感覚を空ける変数</summary>
    private float coolDownTimer = 0;
    public float timeInterval = 0.2f;

    [SerializeField] ObjectPoolController ObjectPoolController;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = new Vector2(0.0f, 0.0f);//プレイヤーの初期位置
    }
    void Update()
    {
        ProcessInputs();//操作をまとめたメソッド
        if(Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
        coolDownTimer -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Move();
    }
   private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection.x = moveX;
        moveDirection.y = moveY;
        moveDirection.Normalize();//斜め移動の値の矯正
    }
    private void Move()
    {
        rb.velocity = moveDirection * moveSpeed;
    }
    private void Fire()
    {
        if (coolDownTimer <= 0)
        {
            GameObject obj = ObjectPoolController.GetPooledObject();
            if(obj ==null)
            {
                return;//全部の弾がアクティブだったら
            }
            //Playerの子オブジェクトを代入
            obj.transform.position = firePos.transform.position;
            obj.transform.rotation = firePos.transform.rotation;
            obj.SetActive(true);
            coolDownTimer = timeInterval;
            // Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);//何を、どこに、どれくらい回転させて
        }
    }
  
}