using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    public EnemyStats enemyStats;
    private Rigidbody rb;
    private NavMeshAgent agent;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = GameManager.Main.player.transform.position;
    }

    public void Damage(float amount)
    {
        enemyStats.life -= amount;

        Popup.Display3DPopup_Static(amount.ToString(), Color.red, this.transform.position, 1.2f);

        if (enemyStats.life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

[System.Serializable]
public class EnemyStats
{
    public float life = 50;
    public float speed = 2;
}
