using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{

    public TextAsset myCSVFile;

    public static string selectedCountry;

    public static int medals;

    public static int games;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeSelf)
        {
            CreateSpheres();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CreateSpheres()
    {
        string[] csvFileLines = myCSVFile.text.Split('\n');
        for (int i = 1; i < csvFileLines.Length - 1; i++)
        {
            string[] values = csvFileLines[i].Split(',');
            GameObject newSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            float x = float.Parse(values[1]);
            float y = float.Parse(values[2]);
            float z = float.Parse(values[3]);

            x = x / 5;
            y = y / 500;
            z = z / 5;

            int r = Random.Range(0, 225);
            int g = Random.Range(0, 225);
            int b = Random.Range(0, 225);

            newSphere.transform.position = new Vector3(x, y, z);

            newSphere.transform.SetParent(this.gameObject.transform);

            newSphere.GetComponent<SphereCollider>().isTrigger = true;

            newSphere.AddComponent<ActionScript>().country = values[0];

            newSphere.AddComponent<ActionScript>().medals = int.Parse(values[1]);

            newSphere.AddComponent<ActionScript>().games = int.Parse(values[2]);

            //Debug.Log(csvFileLines[i]);

            Renderer renderer = newSphere.GetComponent<Renderer>();
            renderer.enabled = false;
            renderer.material.color = new Color32((byte)r, (byte)g, (byte)b, 255);
        }

    }
}
