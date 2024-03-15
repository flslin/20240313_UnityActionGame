using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public Text nameText;
    public Text inputText;

    public int attack;
    public int decay;
    public int strength;
    public int exp;

    Dictionary<string, string> items = new Dictionary<string, string>
    {
        { "name", ""}, {"attack", ""}, {"depense",""}, {"wearLevel",""}, {"exp",""}
    };


    public void InputName()
    {
        nameText.GetComponent<Text>();

        if (items.ContainsKey("name") )
        {
            items[nameText.text] = $"{attack}";
        }
    }
}
