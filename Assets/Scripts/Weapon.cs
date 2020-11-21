using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName ="Custom/Weapon")]
public class Weapon : ScriptableObject
{
    public float dmg;
    public float fireRate;
    public float reloadingTime;
    public int maxAmmo;
    public float spray;
    public Ammo ammoPrefab;
    public float ammoSpeed;
    public float ammoSize;
    public bool burst;
    public int ammoPerShot;

    [HideInInspector] public int currentAmmo;
    [HideInInspector] public float shootTimer;
    [HideInInspector] public float reloadTimer;

    public bool CanShoot
    {
        get { return currentAmmo > 0 && shootTimer <= 0; }
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
        reloadTimer = reloadingTime;
        shootTimer = 0;
    }
}
