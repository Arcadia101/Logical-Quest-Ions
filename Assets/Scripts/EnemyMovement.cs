using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject SkillPrefab;
    public GameObject Player;

    private float LastCast;
    private int Health = 5;

    public void Update()
    {
        if(Player == null) return;

        Vector3 direction = Player.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if(distance < 1.0f && Time.time > LastCast + 0.25f)
        {
            Attack();
            LastCast = Time.time;
        }
    }


    private void Attack()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject skill = Instantiate(SkillPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        skill.GetComponent<SkillScript>().SetDirection(direction);
    }
    
    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }
}
