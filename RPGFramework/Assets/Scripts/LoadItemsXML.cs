using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class LoadItemsXML : MonoBehaviour {

    public TextAsset xmlRawFile;

	void Start () {
        
        string data = loadXMLStandalone("Items.xml");
        parseXml(data);
    }

    string loadXMLStandalone(string fileName)
    {

        string path = Path.Combine("Resources", fileName);
        path = Path.Combine(Application.dataPath, path);
        StreamReader streamReader = new StreamReader(path);
        string streamString = streamReader.ReadToEnd();
        return streamString;
    }

    void parseXml(string itemsXml)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(itemsXml));
        string xmlPath = "//items/item";
        XmlNodeList itemsNodeList = xmlDoc.SelectNodes(xmlPath);

        foreach (XmlNode itemNode in itemsNodeList)
        {
            string itemName = itemNode.SelectSingleNode("name").InnerXml;
            int function = int.Parse(itemNode.SelectSingleNode("function").InnerXml);
            string debuff = "";
            if(itemNode.SelectSingleNode("debuff") != null)
            {
                debuff = itemNode.SelectSingleNode("debuff").InnerXml;
            }

            int value = 0;
            if (itemNode.SelectSingleNode("value") != null)
            {
                value = int.Parse(itemNode.SelectSingleNode("value").InnerXml);
            }

            gameObject.AddComponent<Item>();
            gameObject.GetComponents<Item>()[gameObject.GetComponents<Item>().Length - 1].fill(itemName, function, debuff, value);
        }
    }

    public Item find(string name)
    {
        for (var i = 0; i < gameObject.GetComponents<Item>().Length; i++)
        {
            if (name == gameObject.GetComponents<Item>()[i].itemName)
            {
                return gameObject.GetComponents<Item>()[i];
            }
        }
        return null;
    }

}
