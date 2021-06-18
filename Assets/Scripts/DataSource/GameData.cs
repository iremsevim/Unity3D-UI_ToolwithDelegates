using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
   
    public List<ItemForSlotDatas> itemForSlotDatas;

    private void Awake()
    {
        instance = this;
    }

  
    [System.Serializable]
    public struct ItemForSlotDatas
    {
        public int ýd;
        public string name;
        public int record;

    }

 }
