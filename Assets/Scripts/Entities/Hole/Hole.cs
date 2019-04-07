using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : InteractableEntityBase
{
    [SerializeField] private Object extraLevelHole;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other == PlayerCollider)
        {
            LoadExtraLevelHole();
        }
    }

    //Player fell in a trap. He is sent to the garbage compressor.
    private void LoadExtraLevelHole()
    {
        SceneManager.LoadScene(extraLevelHole.name);
    }
}
