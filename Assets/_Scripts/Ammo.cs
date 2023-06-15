using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
   [SerializeField] private int ammoAmmount = 10;
   

   public int AmmoAmmount
   {
      get => ammoAmmount;
      set => ammoAmmount = value;
   }

   public void ReduceCurrentAmmo()
   {
      ammoAmmount--;
   }
}
