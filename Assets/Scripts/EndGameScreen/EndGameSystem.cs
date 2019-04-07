using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameSystem : MonoBehaviour
{
   [SerializeField] private Button buttonContinue;
   [SerializeField] private Object firstLevel;
   
   private void Start()
   {
      buttonContinue.onClick.AddListener(OnPressContinue);
   }

   private void OnPressContinue()
   {
      SceneManager.LoadScene(firstLevel.name);
   }
}
