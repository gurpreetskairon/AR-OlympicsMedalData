using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text myText;

    public string countryName;

    public int medals;

    public int games;

    public int gold;

    public int silver;

    public int bronze;

    public string[] values;

    public TextAsset myCSVFile;

    // Start is called before the first frame update
    void Start()
    {
        if(BarGraphExample.olympicType == "winter"){
            Winter();
        }
        else if(BarGraphExample.olympicType == "summer"){
            Summer();
        }
        else
        {
            Both();
        }
    }

    public void Both()
    {
        countryName = StartScript.selectedCountry;

        string[] csvFileLines = myCSVFile.text.Split('\n');
        for (int i = 1; i < csvFileLines.Length - 1; i++)
        {
            values = csvFileLines[i].Split(',');

            if (values[0] == countryName)
            {

                games = int.Parse(values[1]);

                medals = int.Parse(values[10]) + int.Parse(values[11]);

            }
        }

        myText = gameObject.GetComponent<Text>();
        myText.text = "\n" + countryName + "\n Games: " + games + "\n Medals: " + medals;
    }

    public void Summer()
    {

        countryName = StartScript.selectedCountry;
        string[] csvFileLines = myCSVFile.text.Split('\n');
        for (int i = 1; i < csvFileLines.Length - 1; i++)
        {
            values = csvFileLines[i].Split(',');

            if (values[0] == countryName)
            {

                medals = int.Parse(values[10]);

                gold = int.Parse(values[4]);

                silver = int.Parse(values[5]);

                bronze = int.Parse(values[6]);
            }
        }

        myText = gameObject.GetComponent<Text>();
        myText.text = "\n" + countryName + " \n Golds: " + gold + " \n Silvers: " + silver + " \n Bronze: " + bronze;
    }

    public void Winter()
    {

        countryName = StartScript.selectedCountry;

        string[] csvFileLines = myCSVFile.text.Split('\n');
        for (int i = 1; i < csvFileLines.Length - 1; i++)
        {
            values = csvFileLines[i].Split(',');

            if (values[0] == countryName)
            {

                gold = int.Parse(values[7]);

                silver = int.Parse(values[8]);

                bronze = int.Parse(values[9]);
            }
        }

        myText = gameObject.GetComponent<Text>();
        myText.text = "\n" + countryName + " \n Golds: " + gold + " \n Silvers: " + silver + " \n Bronze: " + bronze;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
