using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    private int skore = 0;

    private void Awake()
    {
      
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void PrictiBod()
    {
        skore++;
        AktualizujSkore();
    }

    private void AktualizujSkore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Skóre: " + skore;
        }
        else
        {
            Debug.LogWarning("Score Text není připojen k ScoreManager!");
        }
    }
}
