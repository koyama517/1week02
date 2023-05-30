using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    private Vector2 dir;

    public bool isHit;

    public int hp;

    private float hitTimer;

    public bool isAttackX;
    public bool isAttackY;

    public bool isLeftAttack;
    public bool isRightAttack;
    public bool isTopAttack;
    public bool isBottomAttack;

    // Start is called before the first frame update
    void Start()
    {
        dir = new Vector3(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (transform.position.x <= -4.5 || transform.position.x >= 4.5)
        {
            if (transform.position.x > 0)
            {
                transform.position = new Vector3(4.4f, transform.position.y, transform.position.z);
                if (!isAttackX)
                {
                    isLeftAttack = true;
                    isAttackX = true;
                }
            }
            else
            {
                transform.position = new Vector3(-4.4f, transform.position.y, transform.position.z);
                if (!isAttackX)
                {
                    isRightAttack = true;
                    isAttackX = true;
                }
            }

            dir.x *= -1;
        }
        if (transform.position.y <= -4.5 || transform.position.y >= 4.5)
        {
            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, 4.4f, transform.position.z);
                if (!isAttackY)
                {
                    isTopAttack = true;
                    isAttackY = true;
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, -4.4f, transform.position.z);
                if (!isAttackY)
                {
                    isBottomAttack = true;
                    isAttackY = true;
                }
            }
            dir.y *= -1;
        }

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

        if (isHit)
        {
            if (hitTimer >= 1)
            {
                isHit = false;
            }
            else
            {
                hitTimer += Time.deltaTime;
            }
        }
        
        GetComponent<Renderer>().material.color = Color.red;

    }

    public void Damage()
    {
        hp -= 1;
        isHit = true;
        GetComponent<Renderer>().material.color = Color.black;

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
                }
            }
        }
    }
}
