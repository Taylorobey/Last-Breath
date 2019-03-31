using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class OxygenSystem : SingletonMB<OxygenSystem>
{
    #region Events

    void Start()
    {
        OxygenTanks = PersistentManagerScript.Instance.OxygenTanks;
        CurrentTime = PersistentManagerScript.Instance.CurrentTime;
    }

    /// <summary>
    /// Dispatched when player consumes an Oxygen Tank.
    /// </summary>
    public static Action<int> OnConsumeOxygenTank = (remaining) => { };
    
    
    /// <summary>
    ///     Dispatched when received a oxygen tank. 
    /// </summary>
    public static Action<int> OnAddTank = (remaining) => { };
    
    /// <summary>
    ///     Dispatched when player ran out of Oxygen. 
    /// </summary>
    public static Action OnDie = () => { };

    /// <summary>
    ///  Dispatched when oxygen is consumed every 
    /// </summary>
    public static Action<float> OnConsumeOxygen = (percent) => { };
    
    /// <summary>
    ///     Dispatched when tanks are empty. 
    /// </summary>
    public static Action OnEmptyTanks = () => { };
    
    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
 
    #region Fields and Properties
    
    [Header("Configurations")]
    [SerializeField] [Range(60, 300)] [Tooltip("Maximum Time")] 
    private int MaxTime = 240;
    
    [SerializeField] [Range(0, 5)] [Tooltip("How many oxygen tanks the player starts the game.")] 
    private int startOxygenTanks = 2;
    
    [SerializeField] [Range(5, 10)] [Tooltip("Maximum number of oxygen tanks the player is able to carry.")] 
    private int maxOxygenTanks = 5;

    [SerializeField] [Range(10, 60)] [Tooltip("How much time the player gains when consume an oxygen tank (in seconds).")]
    private int timeBoostOxygenTank = 10;

    [SerializeField] [Tooltip("Key used to consume an oxygen tank.")]
    private KeyCode keyInputConsumeTank = KeyCode.Space;

    private int OxygenTanks { get; set; }
    private float CurrentTime { get; set; }

    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
    
    #region Unitycallbacks 

    protected override void OnAwake()
    {
       if (PersistentManagerScript.Instance.OxygenTanks == 0)
       {
            //assign the starting amount of tanks
            OxygenTanks = startOxygenTanks;

            //start the time with the maximum
            CurrentTime = MaxTime;
            PersistentManagerScript.Instance.OxygenTanks = OxygenTanks;
            PersistentManagerScript.Instance.CurrentTime = CurrentTime;
       }
    }

    private void Update()
    {
        CountTime();
        CheckInput();
        PersistentManagerScript.Instance.OxygenTanks = OxygenTanks;
        PersistentManagerScript.Instance.CurrentTime = CurrentTime;
    }
    
    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
    
    #region Methods
    
    private void CountTime()
    {
        //decrement time
        CurrentTime -= Time.deltaTime;

        //kill or consume oxygen
        if (CurrentTime <= 0)
            Die();
        else
            OnConsumeOxygen?.Invoke((float)CurrentTime/(float)MaxTime);
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(keyInputConsumeTank))
            TryConsumeOxygenTank();
    }

    [Button("Kill Player")]
    private void Die()
    {
        CurrentTime = 0;
        OnDie?.Invoke();
        OnConsumeOxygen?.Invoke(0);
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    [Button("Consume Tank")]
    private void TryConsumeOxygenTank()
    {
        if (OxygenTanks <= 0)
            OnEmptyTanks?.Invoke();
        else 
        {
            CurrentTime += timeBoostOxygenTank;
            OxygenTanks--;
            OnConsumeOxygenTank?.Invoke(OxygenTanks);
        }
    }

    [Button]
    public void AddTank()
    {
        OxygenTanks++;
        OnAddTank?.Invoke(OxygenTanks);
    }

    [Button]
    private void RemoveTime()
    {
        CurrentTime -= 10;
    }
    
    #endregion
}
