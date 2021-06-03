using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    public UIManiger UI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        healthManiger hm = collision.gameObject.GetComponent<healthManiger>();
        if (hm != null)
        {
            hm.DealDamage(hm.getMaxHeath);
            if (UI != null)
            {
                UI.showDeathscreen();
            }
        }
    }
}
