using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class LoadSpellsXML : MonoBehaviour {

    public TextAsset xmlRawFile;

    // Use this for initialization
    void Start()
    {        
        string data = loadXMLStandalone("Spells.xml");
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

    void parseXml(string spellsXml)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(spellsXml));
        string xmlPath = "//spells/spell";
        XmlNodeList spellsNodeList = xmlDoc.SelectNodes(xmlPath);

        foreach (XmlNode spellNode in spellsNodeList)
        {
            string abilityName = spellNode.SelectSingleNode("abilityname").InnerXml;
            string type = spellNode.SelectSingleNode("type").InnerXml;
            XmlNode effectNode = spellNode.SelectSingleNode("effect");
            string effectName = "";
            float effectChance = 0; ;
            if (effectNode != null)
            {
                effectName = effectNode.SelectSingleNode("name").InnerXml;
                effectChance = float.Parse(effectNode.SelectSingleNode("chance").InnerXml);
            }

            Effect effect = new Effect(effectName, effectChance);

            string element = "";
            if (spellNode.SelectSingleNode("element") != null)
            {
                element = spellNode.SelectSingleNode("element").InnerXml;
            }

            int manaCost = int.Parse(spellNode.SelectSingleNode("manacost").InnerXml);
            int mt = int.Parse(spellNode.SelectSingleNode("mt").InnerXml);
            bool isSupport = false;
            if (spellNode.SelectSingleNode("issupport").InnerXml == "t")
            {
                isSupport = true;
            }
            gameObject.AddComponent<Spell>();
            gameObject.GetComponents<Spell>()[gameObject.GetComponents<Spell>().Length - 1].fill(abilityName, type, effect, element, manaCost, mt, isSupport);
            //Debug.Log("test");
        }
    }

    public Spell find(string name)
    {
        for (var i = 0; i < gameObject.GetComponents<Spell>().Length; i++)
        {
            if (name == gameObject.GetComponents<Spell>()[i].abilityName)
            {
                return gameObject.GetComponents<Spell>()[i];
            }
        }
        return null;
    }
}
