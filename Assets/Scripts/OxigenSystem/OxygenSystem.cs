using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

public class OxygenSystem : SingletonMB<OxygenSystem>
{
    #region Events

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
    ///  Dispatched when oxygen is consumed every 
    /// </summary>
    public static Action<int> OnConsumeOxygenInSeconds = (current) => { };
    
    /// <summary>
    ///     Dispatched when tanks are empty. 
    /// </summary>
    public static Action OnEmptyTanks = () => { };

    /// <summary>
    /// Dispatched when player takes damage.
    /// </summary>
    public static Action<int> OnTakeDamage = (amount) => { };
    
    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
 
    #region Fields and Properties
    
    public static bool IsInitialized { get; private set; }
    
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
    
    private bool IsDead { get; set; }

    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
    
    #region Unitycallbacks 

    private void Start()
    {
        if (!IsInitialized)
           Restart();
        else
        {
            //load persisted values between levels
            OxygenTanks = PersistentManagerScript.Instance.OxygenTanks;
            CurrentTime = PersistentManagerScript.Instance.CurrentTime;
        }
        
        OnAddTank?.Invoke(OxygenTanks);
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
        {
            OnConsumeOxygen?.Invoke((float) CurrentTime / (float) MaxTime);
            OnConsumeOxygenInSeconds?.Invoke((int)CurrentTime);
        }
    }

    private void CheckInput()
    {
        // Consume tank
        if (Input.GetKeyDown(keyInputConsumeTank))
            TryConsumeOxygenTank();
        if(Input.GetKeyDown("joystick button 1") == true)
        {TryConsumeOxygenTank();}

        // Shoot air cannon
        if (Input.GetKeyDown("joystick button 0") == true && PersistentManagerScript.Instance.gun == true)
        { CurrentTime -= 5; }
        if (Input.GetKeyDown("f") && PersistentManagerScript.Instance.gun == true)
        { CurrentTime -= 5; }
    }

    private void Die()
    {
        if (IsDead)
            return;
        CurrentTime = -1;
        IsDead = true;
        OnConsumeOxygen?.Invoke(0);
        OnDie?.Invoke();
        Restart();
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
    public void AddTank(OxygenTankType type)
    {
        OxygenTanks += (int) type;
        
        //not over loot
        if (OxygenTanks > maxOxygenTanks)
            OxygenTanks = maxOxygenTanks;
        
        OnAddTank?.Invoke(OxygenTanks);
    }

    [Button("Kill Player")]
    private void Kill()
    {
        CurrentTime = 0.5f;
    }

    [Button]
    private void RemoveTime()
    {
        RemoveTime(20);
    }
    
    
    public void RemoveTime(int time = 10)
    {
        CurrentTime -= time;
        OnTakeDamage?.Invoke(time);
    }

    /// <summary>
    ///     Assign the fields the starting values.
    /// </summary>
    private void Restart()
    {
        //assign the starting amount of tanks for the first time
        OxygenTanks = startOxygenTanks;
        //start the time with the maximum
        CurrentTime = MaxTime;
        IsInitialized = true;
        IsDead = false;
    }
    
    #endregion
}
