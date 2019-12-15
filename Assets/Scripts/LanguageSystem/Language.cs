using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;



public class Language
{
    public enum Languages
    {
        castellano,
        catalan
    }

    public static Languages currentLanguage = Languages.castellano;

    private static XmlDocument document;
    public static void Init()
    {
        document = new XmlDocument();
        Debug.Log(Application.dataPath + "/languages.xml");
        document.Load(Application.dataPath + "/languages.xml");
    }

    public static void SetLanguage(Languages language)
    {
        Language.currentLanguage = language;
    }

    public static string RequestText(string id)
    {
        if(document == null)
        {
            Init();
        }

        XmlNode node = document.DocumentElement.SelectSingleNode(id);
        XmlNode lNode = node.SelectSingleNode(currentLanguage.ToString());
        return lNode.InnerText;
    }

}
