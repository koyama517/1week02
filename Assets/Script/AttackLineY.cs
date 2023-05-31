using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLineY : MonoBehaviour
{
    Vector2 lineDir;


    //’e
    public GameObject bulletPrefab;
    private GameObject bullet;

    public int speed;
    float easeSpeed;

    float bulletCount;

    public bool isShoted;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Enemy enemyAttack;
        GameObject enemy = GameObject.Find("Enemy(Clone)");
        if (enemy != null)
        {
            enemyAttack = enemy.GetComponent<Enemy>();
            if (enemyAttack != null)
            {
                if (enemyAttack.isAlive)
                {
                    if (enemyAttack.isTopAttack)
                    {
                        //Debug.Log(lineDir);
                        lineDir = new Vector2(-1, 0);
                        if (transform.position.y > 1)
                        {
                            easeSpeed += 0.1f;
                            transform.Translate(lineDir * (speed + easeSpeed) * Time.deltaTime);
                        }
                        else
                        {
                            if (bulletCount > 0.5f)
                            {
                                ShotToUp();
                            }
                            else
                            {
                                bulletCount += Time.deltaTime;
                            }
                        }

                        if (isShoted)
                        {
                            if (bullet == null)
                            {
                                if (enemyAttack.hp > 5) { easeSpeed += 0.1f; }
                                else { easeSpeed += 0.3f; }
                                transform.Translate(lineDir * (speed + easeSpeed) * Time.deltaTime);
                                if (transform.position.y <= -20)
                                {
                                    Destroy(gameObject);
                                }
                            }
                        }
                    }

                    if (enemyAttack.isBottomAttack)
                    {
                        lineDir = new Vector2(1, 0);
                        if (transform.position.y < -1)
                        {
                            easeSpeed += 0.1f;
                            transform.Translate(lineDir * (speed + easeSpeed) * Time.deltaTime);
                        }
                        else
                        {
                            if (bulletCount > 0.5f)
                            {
                                ShotToDown();
                            }
                            else
                            {
                                bulletCount += Time.deltaTime;
                                Debug.Log(bulletCount);
                            }
                        }

                        if (isShoted)
                        {
                            if (bullet == null)
                            {
                                if (enemyAttack.hp > 5) { easeSpeed += 0.1f; }
                                else { easeSpeed += 0.3f; }
                                transform.Translate(lineDir * (speed + easeSpeed) * Time.deltaTime);
                                if (transform.position.y >= 20)
                                {
                                    Destroy(gameObject);
                                }
                            }
                        }
                    }
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void ShotToUp()
    {
        if (!isShoted)
        {
            bullet = Instantiate(bulletPrefab,
            new Vector3(transform.position.x, 5, -6),
            Quaternion.identity);
            easeSpeed = 0;
            isShoted = true;
        }
    }

    void ShotToDown()
    {
        if (!isShoted)
        {
            bullet = Instantiate(bulletPrefab,
            new Vector3(transform.position.x, -5, -6),
            Quaternion.identity);
            easeSpeed = 0;
            isShoted = true;
        }
    }

}
