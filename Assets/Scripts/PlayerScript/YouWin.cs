using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{

    public static bool Win = true;
    public GameObject Winscreen;
    

    // Start is called before the first frame update
    void Start()
    {
        Win = false;
        Winscreen.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Finish"))
        {
            Win = true;
            Winscreen.SetActive(true);
        }
    }
}
