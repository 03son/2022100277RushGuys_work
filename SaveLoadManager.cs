using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager
{
    public static void SavePlayer(PlayerInformationManager player)
    { 
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/Player.sav", FileMode.Create);

        PlayerData data = new PlayerData(player);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static int[] LoadPlayer()
    {
        if (File.Exists(Application.persistentDataPath + "/Player.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/Player.sav", FileMode.Create);
            
            PlayerData data = bf.Deserialize(stream) as PlayerData;

            stream.Close();

            return data.PlayerCharacter;
        }
        else
        {
           
            return new int[7];
        }
    }
}

[Serializable]
public class PlayerData 
{
    public int[] PlayerCharacter;

    public PlayerData(PlayerInformationManager player) 
    {
        PlayerCharacter = new int[7];
        PlayerCharacter[0] = player.PlayerCharacterNum;
        PlayerCharacter[1] = player.PlayerCharacterSkinNum_Rabbit;
        PlayerCharacter[2] = player.PlayerCharacterSkinNum_Bear;
        PlayerCharacter[3] = player.PlayerCharacterSkinNum_Duck;
        PlayerCharacter[4] = player.PlayerCharacterSkinNum_Penguin;
        PlayerCharacter[5] = player.PlayerKeyNumber;
        PlayerCharacter[6] = player.TutorialValue;
    }
}
