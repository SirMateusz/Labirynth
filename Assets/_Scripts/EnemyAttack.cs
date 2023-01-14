using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int Damage;

    public void Attack()
    {
        GameManager.gameManager.TakeDamage(Damage);
    }
}
