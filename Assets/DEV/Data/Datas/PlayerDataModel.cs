using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerDataModel : DataModel
{
    public static PlayerDataModel Data;
    public float Money = 100;
    public int Level = 1;
    public string PlayerTeam = "";

    public PlayerDataModel Load()
    {
        if (Data == null)
        {
            Data = this;
            object data = LoadData();

            if (data != null)
            {
                Data = (PlayerDataModel)data;
            }
            else
            {
                
            }
        }

        return Data;
    }


    public void Save()
    {
        Save(Data);
    }

}
