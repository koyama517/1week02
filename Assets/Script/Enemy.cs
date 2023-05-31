using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float speed;

    private Vector2 dir;

    bool isActive;

    public bool isHit;

    public int hp;

    private float hitTimer;

    public bool isAttackX;
    public bool isAttackY;

    public bool isLeftAttack;
    public bool isRightAttack;
    public bool isTopAttack;
    public bool isBottomAttack;

    public bool isAlive;

    public float time;
    public float mag;
    public float deadCount;

    // Start is called before the first frame update
    void Start()
    {
        dir = new Vector3(1, 1);
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            if (isHit)
            {
                isActive = true;
            }
        }
        else
        {
            if (hp < 5)
            {
                speed = 2.0f;
            }
            else
            {
                speed = 1.8f;
            }
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
                    dir.x = Random.Range(-2.5f, -1);
                }
                else
                {
                    transform.position = new Vector3(-4.4f, transform.position.y, transform.position.z);
                    if (!isAttackX)
                    {
                        isRightAttack = true;
                        isAttackX = true;
                    }
                    dir.x = Random.Range(1, 2.5f);
                }

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
                    dir.y = Random.Range(-2.5f, -1);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, -4.4f, transform.position.z);
                    if (!isAttackY)
                    {
                        isBottomAttack = true;
                        isAttackY = true;
                    }
                    dir.y = Random.Range(1, 2.5f);
                }
            }

            if (hp <= 0)
            {
                isAlive = false;
                if (deadCount > 2)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    Shake(1, 1);
                    deadCount += Time.deltaTime;
                }
            }

            if (isHit)
            {
                if (hitTimer >= 0.5f)
                {
                    isHit = false;
                    hitTimer = 0;
                    if (hp < 5)
                    {
                        GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.2f); ;
                    }
                }
                else
                {
                    hitTimer += Time.deltaTime;
                    GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.0f, 0.0f); ;
                }
            }
        }
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(TheShake(duration, magnitude));
    }
    private IEnumerator TheShake(float duration, float magnitude)
    {
        Vector3 pos = transform.localPosition;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-1f, 1f) * magnitude;
            var y = pos.y + Random.Range(-1f, 1) * magnitude;

            transform.localPosition = new Vector3(x, y, pos.z);
            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = pos;
    }
    public void Damage()
    {
        hp -= 1;
        isHit = true;
        Shake(time, mag);

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
