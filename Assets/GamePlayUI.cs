using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour {

    public static GamePlayUI Instance { get; private set; }

    public string menuSceneName;
    
    public GameObject winPanelRef;
    public GameObject losePanelRef;


    protected int loadLevelIndex;

    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void SetActiveAndPause(GameObject obj)
    {
        obj.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetDeactiveAndUnpause(GameObject obj)
    {
        obj.SetActive(false);
        Time.timeScale = 1;
    }


    public void ShowWinPanel(int nextLevelIndex)
    {
        loadLevelIndex = nextLevelIndex;
        SetActiveAndPause(winPanelRef);
    }

    public void ShowLosePanel()
    {
        SetActiveAndPause(losePanelRef);
    }

    public void OnClickLoadLevel()
    {
        GameConsistantData.Instance.LoadLevel(loadLevelIndex);
    }

    public void Restart()
    {
        GameConsistantData.Instance.LoadLevel(GameConsistantData.Instance.CurrentLevelIndex);
    }


    private void OnDisable()
    {
        Time.timeScale = 1;
    }

}
