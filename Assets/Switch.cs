using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject lights;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerController3D>(out PlayerController3D player))
        {
            if (player.playerInputs.InteractIsPressed)
            {
                Debug.Log("lights on");
                lights.SetActive(!lights.activeSelf);
            }
        }
    }
}
