using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translator : MonoBehaviour
{
    [SerializeField] List<LanguagePair> labelToId = new List<LanguagePair>();

    void Start()
    {
        if (labelToId == null) return;

        foreach (LanguagePair p in labelToId) {
            p.label.SetText(Language.RequestText(p.id));
        }
    }

    public void UpdateLanguage(int languageIndex)
    {
        Language.currentLanguage = (Language.Languages) languageIndex;
        Start();
    }

    [System.Serializable]
    public class LanguagePair{
        public TextMeshProUGUI label;
        public string id;

        public LanguagePair(TextMeshProUGUI label, string id)
        {
            this.label = label;
            this.id = id;
        }
    }
}
