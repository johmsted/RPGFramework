using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class LoadSave : MonoBehaviour
{

    public static LoadSave ls;

    public List<Character> charList = new List<Character>();
    public LoadSaveCharacters lsc;

    void Awake()
    {
        if (ls == null)
        {
            DontDestroyOnLoad(gameObject);
            ls = this;
        }
        else if (ls != this)
        {
            Destroy(gameObject);
        }
    }

    public void BattleSave()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");

        SaveData saveData = new SaveData();
        lsc.saveChars();

        for (var i = 0; i < charList.Count; i++)
        {
            saveData.charList.Add(charList[i].convertToSerializable());
        }

        for (var i = 0; i < Inventory.inventory.items.Count; i++)
        {
            saveData.inventory.Add(Inventory.inventory.items[i].convertToSerializable());
        }

        bf.Serialize(file, saveData);
        file.Close();

        Debug.Log("Saved!");
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");

        SaveData saveData = new SaveData();

        for (var i = 0; i < charList.Count; i++)
        {
            saveData.charList.Add(charList[i].convertToSerializable());
        }

        for (var i = 0; i < Inventory.inventory.items.Count; i++)
        {
            saveData.inventory.Add(Inventory.inventory.items[i].convertToSerializable());
        }

        bf.Serialize(file, saveData);
        file.Close();

        Debug.Log("Saved!");
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            SaveData saveData = (SaveData)bf.Deserialize(file);
            file.Close();



            for (var i = 0; i < saveData.charList.Count; i++)
            {
                gameObject.AddComponent<Character>();
                gameObject.GetComponents<Character>()[i].convertToMono(saveData.charList[i]);
                charList.Add(gameObject.GetComponents<Character>()[i]);

            }

            for (var i = 0; i < saveData.inventory.Count; i++)
            {
                Inventory.inventory.gameObject.AddComponent<Item>();
                Inventory.inventory.gameObject.GetComponents<Item>()[i].convertToMono(saveData.inventory[i]);
                Inventory.inventory.items.Add(Inventory.inventory.gameObject.GetComponents<Item>()[i]);

            }
            Debug.Log("Loaded!");

            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Didn't find file!");
        }
    }
}

[Serializable]
class SaveData
{
    public List<ItemSaveData> inventory = new List<ItemSaveData>();
    public List<CharacterSaveData> charList = new List<CharacterSaveData>();
}
