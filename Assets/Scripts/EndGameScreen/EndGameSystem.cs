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
      PersistentManagerScript.Instance.OxygenTanks = 2;
        PersistentManagerScript.Instance.CurrentTime = 0f;
        PersistentManagerScript.Instance.SpawnPoint = 0;
        PersistentManagerScript.Instance.gun = false;
        PersistentManagerScript.Instance.remainingtime = 300;
        PersistentManagerScript.Instance.currentkeys = 0;
        PersistentManagerScript.Instance.currentkeysneeded = 0;
      SceneManager.LoadScene("Level0Start");
   }
}
