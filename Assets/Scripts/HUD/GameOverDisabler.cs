using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDisabler : MonoBehaviour
{
    void Start()
    {
        OxygenSystem.OnDie += Disable;
    }

    private void OnDestroy()
    {
        //unsubscribe death trigger
        OxygenSystem.OnDie -= Disable;
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

}
