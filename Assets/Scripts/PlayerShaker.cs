using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

[RequireComponent(typeof(ShakeAnimation))]
public class PlayerShaker : MonoBehaviour
{
   private ShakeAnimation MyShaker { get; set; }
   private void Start()
   {
      MyShaker = GetComponent<ShakeAnimation>();
      OxygenSystem.OnTakeDamage += TakeDamage;
   }

   private void TakeDamage(int amount)
   {
      MyShaker.Shake();
   }

   private void OnDestroy()
   {
      OxygenSystem.OnTakeDamage -= TakeDamage;
   }
}
