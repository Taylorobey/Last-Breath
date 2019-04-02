using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameOverSystem : SingletonMB<GameOverSystem>
{
    //------------------------------------------------------------------------------------------------------------------
    #region Unitycallbacks

    protected override void OnAwake()
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

    protected override void OnDestroy()
    {
        //unsubscribe death trigger
        OxygenSystem.OnDie -= ShowGameOverScreen;
        base.OnDestroy();
    }

    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
    
    #region Properties and Fields
    
    [SerializeField] private GameObject content;
    [SerializeField] private Button buttonPlayAgain;
    [SerializeField] [Tooltip("First Scene of the Game. It is loaded when Play Again Button is pressed.")]
    private Object firstScene;

    #endregion

    //------------------------------------------------------------------------------------------------------------------

    #region Methods

    private void OnPressPlayAgain()
    {
        //call the persistent manager to restart the game
        PersistentManagerScript.Instance.RestartValues();
        
        HideGameOverScreen();
        
        //switch game to first scene
        var firstSceneName = firstScene.name;
        SceneManager.LoadScene(firstSceneName);
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
