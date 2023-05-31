using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //プレハブの読込
    public GameObject roadBulletPrefab;
    private GameObject roadNormalX;
    private GameObject roadNormalY;

    private GameObject roadDiagonalX;
    private GameObject roadDiagonalY;

    //プレイヤーの速度
    public float speed;
    Vector2 movedDir;
    //攻撃間隔
    public float attackCount = 0;

    public int attackInterval;
    //斜めか
    public bool isDiagonal;
    //道か
    RaycastHit2D check;

    public int hp;

    public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        roadDiagonalX = Instantiate(
           roadBulletPrefab,
           new Vector3(transform.position.x,
           transform.position.y, -2),
           Quaternion.Euler(0, 0, -45));

        roadDiagonalY = Instantiate(
            roadBulletPrefab,
            new Vector3(transform.position.x,
            transform.position.y, -2),
            Quaternion.Euler(0, 0, 45));
        isDiagonal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            Enemy enemyHp;
            GameObject enemy = GameObject.Find("Enemy(Clone)");
            if (enemy != null)
            {
                enemyHp = enemy.GetComponent<Enemy>();
                if (enemyHp != null)
                {
                    if (enemyHp.isAlive)
                    {
                        Move();
                        Shot();
                        live();
                    }
                }
            }
        }
        else
        {
            Move();
            Shot();
            live();
        }
        
    }

    void Move()
    {
        movedDir = new Vector2(0, 0);
        //左
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movedDir.x = -1;
        }
        //右
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movedDir.x = 1;
        }
        //上
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movedDir.y = 1;
        }
        //下
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movedDir.y = -1;
        }

        check = CheckWay(movedDir);

        if (check.collider != null)
        {
            if (check.collider.tag == "Way")
            {
                transform.Translate(movedDir * speed * Time.deltaTime);
            }
        }
        if (transform.position.y <= -4.5 || transform.position.y >= 4.5)
        {
            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, 4.4f, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, -4.4f, transform.position.z);
            }
        }
        if (transform.position.x <= -4.5 || transform.position.x >= 4.5)
        {
            if (transform.position.x > 0)
            {
                transform.position = new Vector3(4.4f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(-4.4f, transform.position.y, transform.position.z);
            }
        }
    }

    void Shot()
    {
        if (attackCount >= attackInterval)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isDiagonal)
                {
                    Destroy(roadDiagonalX);
                    Destroy(roadDiagonalY);
                    AttackDiagonal();
                }
                else
                {
                    Destroy(roadNormalX);
                    Destroy(roadNormalY);
                    Attack();
                }
                attackCount = 0;
            }
        }
        else
        {
            attackCount += Time.deltaTime;
        }
    }

    void Attack()
    {
        roadNormalX = Instantiate(
            roadBulletPrefab,
            new Vector3(transform.position.x,
            transform.position.y, -2),
            Quaternion.identity);

        roadNormalY = Instantiate(
            roadBulletPrefab,
            new Vector3(transform.position.x,
            transform.position.y, -2),
            Quaternion.Euler(0, 0, 90));
        isDiagonal = true;
    }

    void AttackDiagonal()
    {
        roadDiagonalX = Instantiate(
            roadBulletPrefab,
            new Vector3(transform.position.x,
            transform.position.y, -2),
            Quaternion.Euler(0, 0, -45));

        roadDiagonalY = Instantiate(
            roadBulletPrefab,
            new Vector3(transform.position.x,
            transform.position.y, -2),
            Quaternion.Euler(0, 0, 45));
        isDiagonal = false;
    }

    RaycastHit2D CheckWay(Vector2 dir)
    {
        Vector3 pos = new Vector3(
            transform.position.x + transform.localScale.x * dir.x,
            transform.position.y + transform.localScale.y * dir.y,
            -2);

        RaycastHit2D result = Physics2D.Raycast(pos, dir, 0);
        return result;
    }

    void live()
    {
        if (isHit)
        {
            hp--;
            isHit = false;
        }
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }
}

