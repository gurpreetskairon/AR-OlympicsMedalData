using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionScript : MonoBehaviour
{

    public string country;

    public int medals;

    public int games;

    public ActionScript(string countryName)
    {
        country = countryName;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //newCube.transform.SetParent(this.gameObject.transform);
        //newCube.transform.position = new Vector3(float.Parse("0.5"), float.Parse("0.5"), float.Parse("0.5"));

        if( country != null)
        {
            StartScript.selectedCountry = country;

            StartScript.medals = medals;

            StartScript.games = games;
        }

        SceneManager.LoadScene("BarGraph");
    }

    public static implicit operator GameObject(ActionScript v)
    {
        throw new NotImplementedException();
    }
}
