using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 dir;

    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy enemyAttack;
        GameObject enemy = GameObject.Find("Enemy(Clone)");
        enemyAttack = enemy.GetComponent<Enemy>();
        if (enemy != null)
        {
            if (enemyAttack != null)
            {
                if (enemyAttack.isLeftAttack)
                {
                    dir = new Vector2(1, 0);
                    transform.Translate(dir * speed * Time.deltaTime);
                    if (transform.position.x >= 5)
                    {
                        Destroy(gameObject);
                    }
                }
                if (enemyAttack.isRightAttack)
                {
                    dir = new Vector2(-1, 0);
                    transform.Translate(dir * speed * Time.deltaTime);
                    if (transform.position.x <= -5)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player playerScript;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerScript = player.GetComponent<Player>();

                if (playerScript != null)
                {
                    playerScript.isHit = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
