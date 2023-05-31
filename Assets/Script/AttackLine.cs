using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLine : MonoBehaviour
{
    Vector2 lineDir;


    //’e
    public GameObject bulletPrefab;
    private GameObject bullet;

    public int speed;
    float easeSpeed;

    public bool isShoted;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(easeSpeed);
        Enemy enemyAttack;
        GameObject enemy = GameObject.Find("Enemy(Clone)");
        if (enemy != null)
        {
            enemyAttack = enemy.GetComponent<Enemy>();
            if (enemyAttack != null)
            {
                if (enemyAttack.isLeftAttack)
                {
                    lineDir = new Vector2(1, 0);
                    if (transform.position.x < -1)
                    {
                        easeSpeed += 0.1f;
                        transform.Translate(lineDir * (speed + easeSpeed) * Time.deltaTime);
                    }
                    else
                    {
                        ShotToLeft();
                    }

                    if (isShoted)
                    {
                        if (bullet == null)
                        {
                            if (enemyAttack.hp > 5) { easeSpeed += 0.1f; }
                            else { easeSpeed += 0.3f; }
                            transform.Translate(lineDir * (speed + easeSpeed) * Time.deltaTime);
                            if (transform.position.x >= 20)
                            {
                                Destroy(gameObject);
                            }
                        }
                    }
                }

                if (enemyAttack.isRightAttack)
                {
                    lineDir = new Vector2(-1, 0);
                    if (transform.position.x > 1)
                    {
                        easeSpeed += 0.1f;
                        transform.Translate(lineDir * (speed + easeSpeed) * Time.deltaTime);
                    }
                    else
                    {
                        ShotToRight();
                    }

                    if (isShoted)
                    {
                        if (bullet == null)
                        {
                            if (enemyAttack.hp > 5) { easeSpeed += 0.1f; }
                            else { easeSpeed += 0.3f; }
                            transform.Translate(lineDir * (speed + easeSpeed) * Time.deltaTime);
                            if (transform.position.x <= -20)
                            {
                                Destroy(gameObject);
                            }
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

    void ShotToLeft()
    {
        if (!isShoted)
        {
            bullet = Instantiate(bulletPrefab,
            new Vector3(-5, transform.position.y, -6),
            Quaternion.identity);
            easeSpeed = 0;
            isShoted = true;
        }
    }

    void ShotToRight()
    {
        if (!isShoted)
        {
            bullet = Instantiate(bulletPrefab,
            new Vector3(5, transform.position.y, -6),
            Quaternion.identity);
            easeSpeed = 0;
            isShoted = true;
        }
    }
}
