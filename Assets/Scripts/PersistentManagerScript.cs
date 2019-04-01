using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }

    public List<string> collectedkeys = new List<string>();
    public int OxygenTanks = 0;
    public float CurrentTime = 0f;
    public int SpawnPoint = 0;
    public bool gun = false;
    public int direction = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
