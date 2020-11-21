using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float ammoSpeed;
    private Weapon weapon;
    private Rigidbody rb;

    public void SetupAmmo(Weapon weapon, Transform weaponCanon)
    {
        Destroy(this.gameObject, 2);

        rb = this.GetComponent<Rigidbody>();

        this.weapon = weapon;

        Vector3 rot = weaponCanon.eulerAngles;
        rot.y += Random.Range(-weapon.spray * .5f, weapon.spray * .5f);
        transform.eulerAngles = rot;
        if (weapon.burst)
        {
            transform.position += transform.right * Random.Range(-.3f, .3f);
        }
        transform.localScale = Vector3.one * weapon.ammoSize;
        ammoSpeed = weapon.ammoSpeed;
    }

    void Update()
    {
        //transform.position += transform.forward * Time.deltaTime * ammoSpeed;
        rb.velocity = transform.forward * ammoSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable prop))
        {
            prop.Damage(weapon.dmg);
        }
        Destroy(this.gameObject);
    }
}
