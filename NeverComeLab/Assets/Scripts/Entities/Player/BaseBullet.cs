using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    protected float damage;
    protected float speed = 5f;
    protected float maxRange;

    protected Rigidbody2D rigid;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage)
    {
        this.damage = damage;
        rigid.velocity = Vector2.zero;
    } 

    protected virtual void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        CheckDead();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Monster monster = collision.GetComponent<Monster>();
            if (monster == null) return;

            OnHit(monster);
            monster.SetPlayerDetected(true);

            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Wall"))
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }

    protected void CheckDead()
    {
        Transform target = GameManager.Instance.player.transform;
        Vector3 targetPos = target.position;
        float dir = Vector3.Distance(targetPos, transform.position);

        // 탄환 별로 발사속도가 다르도록 설정 
        if (dir > maxRange)
        {
            this.gameObject.SetActive(false);
            rigid.velocity = Vector2.zero;
        }
    }

    protected abstract void OnHit(Monster monster);
    
}
