using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tools;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OxygenHud : MonoBehaviour
{
    //------------------------------------------------------------------------------------------------------------------

    private const string Tanks = "Tanks: ";
    
    #region Fields and Properties

    [SerializeField] private Image myFillArea;
    [SerializeField] private Gradient myGradient;
    [SerializeField] private Slider mySlider;
    [SerializeField] private TextMeshProUGUI textTanks;
    
    private ShakeAnimation MyShake { get; set; }

    #endregion
    
    //------------------------------------------------------------------------------------------------------------------

    #region Unitycallbacks
    
    private void Awake()
    {
        MyShake = GetComponent<ShakeAnimation>();
        
        //subscribe
        OxygenSystem.OnConsumeOxygen += OnConsumeOxygen;
        OxygenSystem.OnEmptyTanks += OnEmptyTanks;
        OxygenSystem.OnConsumeOxygenTank += WriteTanksQuantity;
        OxygenSystem.OnAddTank += WriteTanksQuantity;
        OxygenSystem.OnTakeDamage += TakeDamage;

    }
    
    private void OnDestroy()
    {
        //unsubscribe
        OxygenSystem.OnConsumeOxygen -= OnConsumeOxygen;
        OxygenSystem.OnEmptyTanks -= OnEmptyTanks;
        OxygenSystem.OnConsumeOxygenTank -= WriteTanksQuantity;
        OxygenSystem.OnAddTank -= WriteTanksQuantity;
        OxygenSystem.OnTakeDamage -= TakeDamage;
    }

    #endregion

    //------------------------------------------------------------------------------------------------------------------
    
    private void OnConsumeOxygen(float percentage)
    {
        mySlider.value = percentage;
        var currentColor = myGradient.Evaluate(percentage);
        myFillArea.color = currentColor;
    }
    
    
    private void OnEmptyTanks()
    {
        MyShake.Shake();
    }
    
    private void WriteTanksQuantity(int quantity)
    {
        textTanks.text = Tanks + quantity;
    }

    private void TakeDamage(int amount)
    {
        MyShake.Shake();
    }
    
}
