using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInfo : MonoBehaviour
{
   public int CurrentLevel;
   
   public int LevelChanged(int MaxLevel)
   {
      CurrentLevel++;
      CurrentLevel = CurrentLevel > MaxLevel ? 0 : CurrentLevel;
      return CurrentLevel;
   }
}
