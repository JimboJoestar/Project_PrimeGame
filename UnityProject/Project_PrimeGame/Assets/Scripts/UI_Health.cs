using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
    [Tooltip("Number of trailers including the first \'locomotive\' section")]
    public GameObject[] trailers = new GameObject[4];
    public Text healthText;
    public float[] trailerHealth;

    void Start()
    {
        trailerHealth = new float[trailers.Length];
    }

    // Update is called once per frame
    void Update()
    {
        GetHealth();
        string healthTextTemp = "";
        for (int i = 0; i < trailerHealth.Length; i++) 
        {
            healthTextTemp += string.Format("Trailer {0}: {1} \n", i+1, trailerHealth[i]);
            //healthTextTemp += "Trailer " + i + ": "+ trailerHealth[i] + "\n";
        }
        healthText.text = healthTextTemp;
        
        
        /*if (trailerHealth.Length == 1)
        {
            healthText.text = "Locomotive Health: " + trailerHealth[0];
        }
        if (trailerHealth.Length == 2)
        {
            healthText.text = "Locomotive Health: " + trailerHealth[0] + "\n Trailer Health: " + trailerHealth[1];
        }
        if (trailerHealth.Length == 3)
        {
            healthText.text = "Locomotive Health: " + trailerHealth[0] + "\n Trailer Health: " + trailerHealth[1] + "\n Trailer Health: " + trailerHealth[2];
        }
        if (trailerHealth.Length == 4)
        {
            healthText.text = "Locomotive Health: " + trailerHealth[0] + "\n Trailer Health: " + trailerHealth[1] + "\n Trailer Health: " + trailerHealth[2] + "\n Trailer Health: " + trailerHealth[3];
        }*/
        
    }

    private void GetHealth() 
    {
        int currentTrailer = 0;
        foreach (GameObject trailer in trailers)
        {
            trailerHealth[currentTrailer] = trailer.GetComponent<Dreadnaught_Health_Script>().health;
            currentTrailer++;
        }

    }
}
