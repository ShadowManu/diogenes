using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Singleton object that handles a player state
 */
public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Singleton pattern

    public GameObject selectedUnit;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }

}
