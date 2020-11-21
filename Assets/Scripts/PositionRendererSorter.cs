using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PositionRendererSorter : MonoBehaviour
{
    private int sortingBaseOrder = 5000;
    [SerializeField] private int offset = 0;
    [SerializeField] private bool runOnlyOnce = true;

    private float timer;
    private float timerMax;
    private Renderer r;

    void Awake()
    {
        r = GetComponent<Renderer>();
    }

    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if(timer<=0f)
        {
            timer = timerMax;
            r.sortingOrder = (int)(sortingBaseOrder - transform.position.y - offset);
        }
        if (runOnlyOnce)
            Destroy(this);
    }
}
