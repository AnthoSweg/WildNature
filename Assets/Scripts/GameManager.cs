using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class GameManager : MonoBehaviour
{
    private static GameManager main;
    public static GameManager Main
    {
        get
        {
            if(main == null)
                main = FindObjectOfType<GameManager>();
            return main;
        }
    }

    public PlayerController3D player;
}

