using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnerRadius;
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        CodeMonkey.Utils.FunctionPeriodic.Create(() => Spawn(), 3);
    }

    void Spawn()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemyPrefab, Utils.RandomCircle(this.transform.position, spawnerRadius), Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, spawnerRadius);
    }
}
