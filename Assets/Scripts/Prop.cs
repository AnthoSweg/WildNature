using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour, IDamageable
{
    public float life = 10;

    public void Damage(float amount)
    {
        life -= amount;

        Popup.Display3DPopup_Static(amount.ToString(), mColors.orange, this.transform.position, 1);

        if (life<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
