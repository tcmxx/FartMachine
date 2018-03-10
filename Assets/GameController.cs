using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController Instance { get; private set; }

    public GameConsistantData gameConsistantDataRef;    //reference the game data so that the GameConsistantData singleton works


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
