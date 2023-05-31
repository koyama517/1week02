using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyHP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy enemyHp;
        GameObject enemy = GameObject.Find("Enemy(Clone)");
        if (enemy != null)
        {
            enemyHp = enemy.GetComponent<Enemy>();
            if (enemyHp != null)
            {
                transform.localScale = new Vector3(20, enemyHp.hp, 0);
            }
        }
    }
}
