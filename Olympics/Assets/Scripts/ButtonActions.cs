using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public Text myText;

    BarGraphExample br = new BarGraphExample();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSummer()
    {
        BarGraphExample.olympicType = "summer";

        SceneManager.LoadScene("BarGraph");
    }

    public void OnWinter()
    {

        BarGraphExample.olympicType = "winter";

        SceneManager.LoadScene("BarGraph");
    }

    public void BothSeasons()
    {

        BarGraphExample.olympicType = "alls";

        SceneManager.LoadScene("BarGraph");
    }

    public void Back()
    {
        SceneManager.LoadScene("Countries");
    }

    public void closeButton()
    {
        Application.Quit();
        Debug.Log("In Log Exit");
    }

}