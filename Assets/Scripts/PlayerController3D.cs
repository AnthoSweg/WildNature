using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController3D : MonoBehaviour
{

    [Header("Links")]
    public Camera cam;
    public PlayerStats playerStats;
    public PlayerInputs playerInputs;
    private PlayerState playerState;
    public Transform weaponCanon;
    public Weapon weapon;
    public Rigidbody rb;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        weapon.currentAmmo = weapon.maxAmmo;
        rb = GetComponent<Rigidbody>();
    }

    //Vector3 mousePos;
    void Update()
    {
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.y = weaponCanon.position.y;
        ////new Vector3(mousePos.x, weaponCanon.position.y, mousePos.y)
        ////weaponCanon.LookAt(new Vector3(mousePos.x, weaponCanon.position.y, mousePos.z));
        ////Debug.Log(weaponCanon.eulerAngles);

        //Vector3 dir = weaponCanon.position - mousePos;
        ////dir = weaponCanon.InverseTransformDirection(dir);
        //Vector3 neewRot = weaponCanon.eulerAngles;
        //neewRot.y = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
        //weaponCanon.eulerAngles = neewRot;

        if (playerInputs.IsButtonDown(PlayerInputs.Button.Fire))
        {
            TryToShoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (weapon.shootTimer > 0)
        {
            weapon.shootTimer -= Time.deltaTime;
        }

        if (playerState == PlayerState.reloading)
        {
            weapon.reloadTimer -= Time.deltaTime;
            if (weapon.reloadTimer <= 0)
            {
                weapon.reloadTimer = 0;
                weapon.currentAmmo = weapon.maxAmmo;
                playerState = PlayerState.normal;
            }
        }

        UpdatePlayerUI();
    }

    private void FixedUpdate()
    {
        Move();
    }

    Vector3 inputs;
    private Vector3 gravity = new Vector3(0, -1, 0);
    private void Move()
    {
        //Add force
        inputs = Vector3.zero;
        //if (Input.GetKey(KeyCode.Z))
        //    inputs.z += playerStats.moveSpeed;
        //if (Input.GetKey(KeyCode.Q))
        //    inputs.x += -playerStats.moveSpeed;
        //if (Input.GetKey(KeyCode.S))
        //    inputs.z += -playerStats.moveSpeed;
        //if (Input.GetKey(KeyCode.D))
        //    inputs.x += playerStats.moveSpeed;

        inputs.x = playerInputs.Horizontal * playerStats.moveSpeed;
        inputs.z = playerInputs.Vertical * playerStats.moveSpeed;
        rb.velocity = inputs + gravity;

        //Define rotation
        var dir = Input.mousePosition - cam.WorldToScreenPoint(this.transform.position);
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.AngleAxis(angle, Vector3.up), playerStats.rotationSpeed * Time.fixedDeltaTime);

        weaponCanon.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }

    private void TryToShoot()
    {
        if (playerState != PlayerState.reloading)
        {
            if (weapon.CanShoot)
            {
                weapon.currentAmmo--;
                weapon.shootTimer = 1 / weapon.fireRate;
                for (int i = 0; i < weapon.ammoPerShot; i++)
                {
                    Instantiate(weapon.ammoPrefab, weaponCanon.position, Quaternion.identity).GetComponent<Ammo>().SetupAmmo(weapon, weaponCanon);                    
                }
            }
            else if(weapon.currentAmmo == 0)
            {
                Reload();
            }
        }
    }

    [Header("UI Links")]
    public TextMeshProUGUI ammoTextMesh;
    public Slider reloadSlider;

    void UpdatePlayerUI()
    {
        ammoTextMesh.text = string.Format("{0} / {1}", weapon.currentAmmo, weapon.maxAmmo);
        if(playerState.Equals(PlayerState.reloading))
        {
            reloadSlider.gameObject.SetActive(true);
            reloadSlider.maxValue = weapon.reloadingTime;
            reloadSlider.value = weapon.reloadTimer;
            ammoTextMesh.text = string.Format("0 / {1}", weapon.currentAmmo, weapon.maxAmmo);
        }
        else if(weapon.shootTimer>0 && weapon.fireRate < 10)
        {
            reloadSlider.gameObject.SetActive(true);
            reloadSlider.maxValue = 1 / weapon.fireRate;
            reloadSlider.value = weapon.shootTimer;
        }
        else
            reloadSlider.gameObject.SetActive(false);

    }

    private void Reload()
    {
        playerState = PlayerState.reloading;
        weapon.Reload();
    }

    public enum PlayerState
    {
        normal,
        reloading,
        stuned
    }
}
