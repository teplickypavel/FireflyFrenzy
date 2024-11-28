using UnityEngine;

public class ChytaniSvetlusky : MonoBehaviour
{
    public KeyCode chytaciKlavesa = KeyCode.X; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ZkontrolujChytani();
        }

        if (Input.GetKeyDown(chytaciKlavesa))
        {
            ZkontrolujChytani();
        }
    }

    private void ZkontrolujChytani()
    {
        Vector3 poziceMysi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        poziceMysi.z = 0;

        if (GetComponent<Collider2D>().bounds.Contains(poziceMysi))
        {
            GetComponent<SvetluskaProlet>().ChytitSvetlusku();
        }
    }
}
