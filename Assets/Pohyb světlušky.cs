using UnityEngine;

public class SvetluskaProlet : MonoBehaviour
{
    public float rychlostPohybu = 5.0f;
    public Vector2 spawnOkrajOffset = new Vector2(8.0f, 6.0f); 
    public GameObject svetluskaPrefab;

    private Vector3 startovniPozice; 
    private Vector3 cilovyBodStred = Vector3.zero;
    private Vector3 cilovyBodKonec;
    private bool letiDoStredu = true; 

    void Start()
    {
        startovniPozice = VypocitejSpawnPozici();
        transform.position = startovniPozice;
        cilovyBodKonec = VypocitejCilKonec();
    }

    void Update()
    {
        if (letiDoStredu)
        {
            transform.position = Vector3.MoveTowards(transform.position, cilovyBodStred, rychlostPohybu * Time.deltaTime);

            if (Vector3.Distance(transform.position, cilovyBodStred) < 0.1f)
            {
                letiDoStredu = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, cilovyBodKonec, rychlostPohybu * Time.deltaTime);

            if (Vector3.Distance(transform.position, cilovyBodKonec) < 0.1f)
            {
                if (LifeManager.instance != null)
                {
                    LifeManager.instance.OdeberZivot();
                }

                SpawnNovaSvetluska();

                Destroy(gameObject);
            }
        }
    }

    public void ChytitSvetlusku()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.PrictiBod();
        }

        SpawnNovaSvetluska();

        Destroy(gameObject);
    }

    private void SpawnNovaSvetluska()
    {
        Vector3 spawnPozice = VypocitejSpawnPozici();
        Instantiate(svetluskaPrefab, spawnPozice, Quaternion.identity);
    }

    private Vector3 VypocitejSpawnPozici()
    {
        int strana = Random.Range(0, 4);
        switch (strana)
        {
            case 0: return new Vector3(Random.Range(-spawnOkrajOffset.x, spawnOkrajOffset.x), spawnOkrajOffset.y, 0);
            case 1: return new Vector3(Random.Range(-spawnOkrajOffset.x, spawnOkrajOffset.x), -spawnOkrajOffset.y, 0);
            case 2: return new Vector3(-spawnOkrajOffset.x, Random.Range(-spawnOkrajOffset.y, spawnOkrajOffset.y), 0);
            case 3: return new Vector3(spawnOkrajOffset.x, Random.Range(-spawnOkrajOffset.y, spawnOkrajOffset.y), 0);
        }
        return Vector3.zero;
    }

    private Vector3 VypocitejCilKonec()
    {
        if (startovniPozice.y == spawnOkrajOffset.y)
            return new Vector3(Random.Range(-spawnOkrajOffset.x, spawnOkrajOffset.x), -spawnOkrajOffset.y, 0);
        if (startovniPozice.y == -spawnOkrajOffset.y)
            return new Vector3(Random.Range(-spawnOkrajOffset.x, spawnOkrajOffset.x), spawnOkrajOffset.y, 0);
        if (startovniPozice.x == -spawnOkrajOffset.x)
            return new Vector3(spawnOkrajOffset.x, Random.Range(-spawnOkrajOffset.y, spawnOkrajOffset.y), 0);
        if (startovniPozice.x == spawnOkrajOffset.x)
            return new Vector3(-spawnOkrajOffset.x, Random.Range(-spawnOkrajOffset.y, spawnOkrajOffset.y), 0);

        return Vector3.zero;
    }
}
