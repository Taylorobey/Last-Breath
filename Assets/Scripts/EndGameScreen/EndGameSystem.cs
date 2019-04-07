using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameSystem : MonoBehaviour
{
   [SerializeField] private Button buttonContinue;
   
   private void Start()
   {
      buttonContinue.onClick.AddListener(OnPressContinue);
   }

   private void OnPressContinue()
   {
      SceneManager.LoadScene("Level0Start");
   }
}
