using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Text hints script*/
public class TextHints : MonoBehaviour
{
    float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        //time when the text hint disappears
        if (gameObject.GetComponent<Text>().enabled)
        {
            timer += Time.deltaTime;
            if (timer >= 8)
            {
                gameObject.GetComponent<Text>().enabled = false;
                timer = 0.0f;
            }
        }
    }
    //method to display text hints
    public void ShowHint(string message) 
    {
        gameObject.GetComponent<Text>().text = message;
        if (!gameObject.GetComponent<Text>().enabled)
        {
            gameObject.GetComponent<Text>().enabled = true;
        }
    }
}
