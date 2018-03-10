using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public int nextLevelIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WinPanel();
        }
    }

    public void WinPanel()
    {
        GamePlayUI.Instance.ShowWinPanel(nextLevelIndex);
    }
}
