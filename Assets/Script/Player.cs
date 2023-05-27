using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //プレハブの読込
    public GameObject roadBulletPrefab;
    private GameObject roadNormalX;
    private GameObject roadNormalY;

    //プレイヤーの速度
    public float speed;
    Vector2 movedDir;
    //攻撃間隔
    float attackCount = 0;
    //斜めか
    bool isDiagonal;
    //道か？
    RaycastHit2D check;
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {

        movedDir = new Vector2(0, 0);
        attackCount += Time.deltaTime;
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

        Debug.Log(check.collider.tag);

        if (attackCount >= 2)
        {
            if (isDiagonal)
            {
                Destroy(roadNormalX);
                Destroy(roadNormalY);
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
        roadNormalX = Instantiate(
            roadBulletPrefab,
            new Vector3(transform.position.x,
            transform.position.y, -2),
            Quaternion.Euler(0, 0, -45));
        
        roadNormalY = Instantiate(
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

        RaycastHit2D result = Physics2D.Raycast(pos,dir,0);
        return result;
    }
}

