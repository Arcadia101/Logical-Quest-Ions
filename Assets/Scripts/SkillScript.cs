using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        //Camera.main.GetComponent<AudioSource>().PlayOneShoot(Sound);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroySkill()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        EnemyMovement enemy = collision.GetComponent<EnemyMovement>();
        if(player != null)
        {
            player.Hit();
        }

        if(enemy != null)
        {
            enemy.Hit();
        }

        DestroySkill();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
    //    EnemyMovement enemy = collision.collider.GetComponent<EnemyMovement>();
    //    if(player != null)
    //    {
    //        player.Hit();
    //    }

    //    if(enemy != null)
    //    {
    //        enemy.Hit();
    //    }

    //    DestroySkill();
    //}
}
