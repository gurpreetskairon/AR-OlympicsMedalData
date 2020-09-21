using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq.Expressions;
using BarGraph.VittorCloud;

public class BarGraphExample : MonoBehaviour
{

    public TextAsset myCSVFile;

    private string currentCountry;

    public List<BarGraphDataSet> exampleDataSet; // public data set for inserting data into the bar graph
    BarGraphGenerator barGraphGenerator;

    public static string olympicType = "all";

    void Start()
    {
        if(olympicType == "summer")
        {
            Summer();
        }
        else if(olympicType == "winter")
        {
            Winter();
        }
        else
        {
            AllSeasons();
        }
        
    }

    public void Summer() {

        if (exampleDataSet.Count != 0)
        {
            exampleDataSet.Clear();
        }

        barGraphGenerator = GetComponent<BarGraphGenerator>();

        currentCountry = StartScript.selectedCountry;

        string[] csvFileLines = myCSVFile.text.Split('\n');
        for (int i = 1; i < csvFileLines.Length - 1; i++)
        {
            string[] values = csvFileLines[i].Split(',');

            List<XYBarValues> slist = new List<XYBarValues>();

            if (values[0] == currentCountry)
            {
                BarGraphDataSet br = new BarGraphDataSet();

                XYBarValues gs = new XYBarValues();

                gs.XValue = "Gold";

                gs.YValue = float.Parse(values[4]);

                slist.Add(gs);

                XYBarValues ss = new XYBarValues();

                ss.XValue = "Silver";

                ss.YValue = float.Parse(values[5]);

                slist.Add(ss);

                XYBarValues bs = new XYBarValues();

                bs.XValue = "bronze";

                bs.YValue = float.Parse(values[6]);

                slist.Add(bs);

                br.GroupName = "Summer";

                br.ListOfBars = slist;

                br.barColor = Color.red;

                exampleDataSet.Add(br);
            }
        }

        if (exampleDataSet.Count == 0)
        {

            //Debug.LogError("ExampleDataSet is Empty!");
            return;
        }
        barGraphGenerator.GeneratBarGraph(exampleDataSet);
    }

    public void Winter() {

        if (exampleDataSet.Count != 0)
        {
            exampleDataSet.Clear();
        }

        barGraphGenerator = GetComponent<BarGraphGenerator>();

        currentCountry = StartScript.selectedCountry;

        string[] csvFileLines = myCSVFile.text.Split('\n');
        for (int i = 1; i < csvFileLines.Length - 1; i++)
        {
            string[] values = csvFileLines[i].Split(',');

            List<XYBarValues> slist = new List<XYBarValues>();

            if (values[0] == currentCountry)
            {
                BarGraphDataSet br = new BarGraphDataSet();

                XYBarValues gs = new XYBarValues();

                gs.XValue = "Gold";

                gs.YValue = float.Parse(values[7]);

                slist.Add(gs);

                XYBarValues ss = new XYBarValues();

                ss.XValue = "Silver";

                ss.YValue = float.Parse(values[8]);

                slist.Add(ss);

                XYBarValues bs = new XYBarValues();

                bs.XValue = "bronze";

                bs.YValue = float.Parse(values[9]);

                slist.Add(bs);

                br.GroupName = "Winter";

                br.ListOfBars = slist;

                br.barColor = Color.blue;

                exampleDataSet.Add(br);
            }
        }

        if (exampleDataSet.Count == 0)
        {

            //Debug.LogError("ExampleDataSet is Empty!");
            return;
        }
        barGraphGenerator.GeneratBarGraph(exampleDataSet);

    }


    public void AllSeasons()

    {

        if(exampleDataSet.Count != 0)
        {
            exampleDataSet.Clear();
        }

        barGraphGenerator = GetComponent<BarGraphGenerator>();

        currentCountry = StartScript.selectedCountry;

        //Debug.Log(" Selected Country " + currentCountry);

        string[] csvFileLines = myCSVFile.text.Split('\n');
        for (int i = 1; i < csvFileLines.Length - 1; i++)
        {
            string[] values = csvFileLines[i].Split(',');

            List<XYBarValues> slist = new List<XYBarValues>();

            List<XYBarValues> wlist = new List<XYBarValues>();

            if (values[0] == currentCountry)
            {
                BarGraphDataSet br = new BarGraphDataSet();

                XYBarValues gs = new XYBarValues();

                gs.XValue = "Gold";

                gs.YValue = float.Parse(values[4]);

                slist.Add(gs);

                XYBarValues ss = new XYBarValues();

                ss.XValue = "Silver";

                ss.YValue = float.Parse(values[5]);

                slist.Add(ss);

                XYBarValues bs = new XYBarValues();

                bs.XValue = "bronze";

                bs.YValue = float.Parse(values[6]);

                slist.Add(bs);

                br.GroupName = "Summer";

                br.ListOfBars = slist;

                br.barColor = Color.red;

                exampleDataSet.Add(br);

                BarGraphDataSet bw = new BarGraphDataSet();

                XYBarValues gw = new XYBarValues();

                gw.XValue = "Gold";

                gw.YValue = float.Parse(values[7]);

                wlist.Add(gw);

                XYBarValues sw = new XYBarValues();

                sw.XValue = "Silver";

                sw.YValue = float.Parse(values[8]);

                wlist.Add(sw);

                XYBarValues tw = new XYBarValues();

                tw.XValue = "bronze";

                tw.YValue = float.Parse(values[9]);

                wlist.Add(tw);

                bw.GroupName = "Winter";

                bw.ListOfBars = wlist;

                bw.barColor = Color.blue;

                exampleDataSet.Add(bw);
            }

        }

        //if the exampleDataSet list is empty then return.
        if (exampleDataSet.Count == 0)
        {

            //Debug.LogError("ExampleDataSet is Empty!");
            return;
        }
        barGraphGenerator.GeneratBarGraph(exampleDataSet);
    }

    //call when the graph starting animation completed,  for updating the data on run time
    public void StartUpdatingGraph()
    {

       
        StartCoroutine(CreateDataSet());
    }



    IEnumerator CreateDataSet()
    {
        //  yield return new WaitForSeconds(3.0f);
        while (true)
        {

            //GenerateRandomData();

            yield return new WaitForSeconds(2.0f);

        }

    }



    //Generates the random data for the created bars
    void GenerateRandomData()
    {
        
        int dataSetIndex = UnityEngine.Random.Range(0, exampleDataSet.Count);
        int xyValueIndex = UnityEngine.Random.Range(0, exampleDataSet[dataSetIndex].ListOfBars.Count);
        exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue = UnityEngine.Random.Range(barGraphGenerator.yMinValue, barGraphGenerator.yMaxValue);
        barGraphGenerator.AddNewDataSet(dataSetIndex, xyValueIndex, exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue);
    }
}



