using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance; 
    public Text livesText; 
    private int zivoty = 100; 

    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        AktualizujText(); 
    }

    public void OdeberZivot()
    {
        zivoty--; 

        if (zivoty <= 0)
        {
            zivoty = 0;
            GameOver();
        }

        AktualizujText(); 
    }

    private void AktualizujText()
    {
        livesText.text = "Životy: " + zivoty;
    }

    private void GameOver()
    {
        Debug.Log("Hráè ztratil všechny životy!");
    }
}
