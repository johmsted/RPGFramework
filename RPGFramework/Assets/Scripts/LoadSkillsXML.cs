using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class LoadSkillsXML : MonoBehaviour {

    //public TextAsset xmlRawFile;

	// Use this for initialization
	void Start () {
        
        string data = loadXMLStandalone("Skills.xml");
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

    void parseXml(string skillsXml)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(skillsXml));
        string xmlPath = "//skills/skill";
        XmlNodeList skillsNodeList = xmlDoc.SelectNodes(xmlPath);

        foreach(XmlNode skillNode in skillsNodeList)
        {
            string abilityName = skillNode.SelectSingleNode("abilityname").InnerXml;
            string type = skillNode.SelectSingleNode("type").InnerXml;
            XmlNode effectNode = skillNode.SelectSingleNode("effect");
            string effectName = "";
            float effectChance = 0; ;
            if (effectNode != null) {
                effectName = effectNode.SelectSingleNode("name").InnerXml;
                effectChance = float.Parse(effectNode.SelectSingleNode("chance").InnerXml);
            }

            Effect effect = new Effect(effectName, effectChance);

            string element = "";
            if(skillNode.SelectSingleNode("element") != null)
            {
                element = skillNode.SelectSingleNode("element").InnerXml;
            }

            int manaCost = int.Parse(skillNode.SelectSingleNode("manacost").InnerXml);
            int mt = int.Parse(skillNode.SelectSingleNode("mt").InnerXml);
            bool isSupport = false;
            if(skillNode.SelectSingleNode("issupport").InnerXml == "t")
            {
                isSupport = true;
            }
            gameObject.AddComponent<Skill>();
            gameObject.GetComponents<Skill>()[gameObject.GetComponents<Skill>().Length-1].fill(abilityName, type, effect, element, manaCost, mt, isSupport);
            //Debug.Log("test");
        }
    }

    public Skill find(string name)
    {
        for(var i = 0; i < gameObject.GetComponents<Skill>().Length; i++)
        {
            if(name == gameObject.GetComponents<Skill>()[i].abilityName)
            {
                return gameObject.GetComponents<Skill>()[i];
            }
        }
        return null;
    }

}
