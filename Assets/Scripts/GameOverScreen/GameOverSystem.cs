using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameOverSystem : MonoBehaviour
{
    //------------------------------------------------------------------------------------------------------------------
    #region Unitycallbacks

    private void Awake()
    {
        //button play again on click event
        buttonPlayAgain.onClick.AddListener(OnPressPlayAgain);
        
        //subscribe death trigger
        OxygenSystem.OnDie += ShowGameOverScreen;
    }

    private void Start()
    {
        //hide screen when the game starts
        HideGameOverScreen();
    }

    private void OnDestroy()
    {
        //unsubscribe death trigger
        OxygenSystem.OnDie -= ShowGameOverScreen;
    }

    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
    
    #region Properties and Fields
    
    [SerializeField] private GameObject content;
    [SerializeField] private Button buttonPlayAgain;

    #endregion

    //------------------------------------------------------------------------------------------------------------------

    #region Methods

    private void OnPressPlayAgain()
    {
        //call the persistent manager to restart the game
        PersistentManagerScript.Instance.RestartValues();
        
        HideGameOverScreen();
        
        //switch game to first scene
        SceneManager.LoadScene("Level0Start");
    }
    
    [Button]
    public void ShowGameOverScreen()
    {
        content.SetActive(true);
    }
    
    
    [Button]
    public void HideGameOverScreen()
    {
        content.SetActive(false);
    }

    #endregion

    //------------------------------------------------------------------------------------------------------------------
}
