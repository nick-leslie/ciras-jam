using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManiger : MonoBehaviour
{
    [SerializeField]
    private GameObject deathScreen;
    public void showDeathscreen()
    {
        deathScreen.SetActive(true);
    }
}
