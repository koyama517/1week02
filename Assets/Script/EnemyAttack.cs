using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public bool isMakePrefabX;
    public bool isMakePrefabY;
    //�\����
    public GameObject attackLinePrefab;
    public GameObject attackLinePrefabY;

    private GameObject attackLine1X;
    private GameObject attackLine2X;
    private GameObject attackLine3X;
    private GameObject attackLine4X;
    private GameObject attackLine5X;

    private GameObject attackLine1Y;
    private GameObject attackLine2Y;
    private GameObject attackLine3Y;
    private GameObject attackLine4Y;
    private GameObject attackLine5Y;
    public int lineSpeed;
    public int dir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Enemy enemy = GetComponent<Enemy>();
        if (enemy != null)
        {
            if (enemy.isLeftAttack)
            {
                LeftAttack();
                if(attackLine1X == null)
                {
                    enemy.isLeftAttack = false;
                    isMakePrefabX = false;
                    enemy.isAttackX = false;
                }
            }
            else if (enemy.isRightAttack)
            {
                RightAttack();
                if (attackLine1X == null)
                {
                    enemy.isRightAttack = false;
                    isMakePrefabX = false;
                    enemy.isAttackX = false;
                }
            }
            if (enemy.isTopAttack)
            {
                TopAttack();
                if (attackLine1Y == null)
                {
                    enemy.isTopAttack = false;
                    isMakePrefabY = false;
                    enemy.isAttackY = false;
                }
            }
            else if (enemy.isBottomAttack)
            {
                BottomAttack();
                if (attackLine1Y == null)
                {
                    enemy.isBottomAttack = false;
                    isMakePrefabY = false;
                    enemy.isAttackY = false;
                }
            }
        }
    }

    void LeftAttack()
    {
        if (!isMakePrefabX)
        {
            attackLine1X = Instantiate(attackLinePrefab, new Vector3(-20, 4.5f, -5), Quaternion.identity);
            attackLine2X = Instantiate(attackLinePrefab, new Vector3(-20, 2.5f, -5), Quaternion.identity);
            attackLine3X = Instantiate(attackLinePrefab, new Vector3(-20, 0.5f, -5), Quaternion.identity);
            attackLine4X = Instantiate(attackLinePrefab, new Vector3(-20, -1.5f, -5), Quaternion.identity);
            attackLine5X = Instantiate(attackLinePrefab, new Vector3(-20, -3.5f, -5), Quaternion.identity);
            isMakePrefabX = true;
        }


    }

    void RightAttack()
    {
        if (!isMakePrefabX)
        {
            attackLine1X = Instantiate(attackLinePrefab, new Vector3(20, 4, -5), Quaternion.identity);
            attackLine2X = Instantiate(attackLinePrefab, new Vector3(20, 2, -5), Quaternion.identity);
            attackLine3X = Instantiate(attackLinePrefab, new Vector3(20, 0, -5), Quaternion.identity);
            attackLine4X = Instantiate(attackLinePrefab, new Vector3(20, -2, -5), Quaternion.identity);
            attackLine5X = Instantiate(attackLinePrefab, new Vector3(20, -4, -5), Quaternion.identity);
            isMakePrefabX = true;
        }
    }

    void TopAttack()
    {
        if (!isMakePrefabY)
        {
            attackLine1Y = Instantiate(attackLinePrefabY, new Vector3(-4, 20, -5), Quaternion.Euler(0,0,90));
            attackLine2Y = Instantiate(attackLinePrefabY, new Vector3(-2, 20, -5), Quaternion.Euler(0, 0, 90));
            attackLine3Y = Instantiate(attackLinePrefabY, new Vector3(0, 20, -5), Quaternion.Euler(0, 0, 90));
            attackLine4Y = Instantiate(attackLinePrefabY, new Vector3(2, 20, -5), Quaternion.Euler(0, 0, 90));
            attackLine5Y = Instantiate(attackLinePrefabY, new Vector3(4, 20, -5), Quaternion.Euler(0, 0, 90));
            isMakePrefabY = true;
        }
    }

    void BottomAttack()
    {
        if (!isMakePrefabY)
        {
            attackLine1Y = Instantiate(attackLinePrefabY, new Vector3(-4, -20, -5), Quaternion.Euler(0, 0, 90));
            attackLine2Y = Instantiate(attackLinePrefabY, new Vector3(-2, -20, -5), Quaternion.Euler(0, 0, 90));
            attackLine3Y = Instantiate(attackLinePrefabY, new Vector3(0, -20, -5), Quaternion.Euler(0, 0, 90));
            attackLine4Y = Instantiate(attackLinePrefabY, new Vector3(2, -20, -5), Quaternion.Euler(0, 0, 90));
            attackLine5Y = Instantiate(attackLinePrefabY, new Vector3(4, -20, -5), Quaternion.Euler(0, 0, 90));
            isMakePrefabY = true;
        }
    }
}