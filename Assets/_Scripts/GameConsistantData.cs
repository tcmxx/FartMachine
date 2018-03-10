using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

[CreateAssetMenuAttribute()]
public class GameConsistantData : ScriptableObject {

    protected static GameConsistantData _instance = null;
    public static GameConsistantData Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = Resources.FindObjectsOfTypeAll<GameConsistantData>().FirstOrDefault();
                _instance.Initialize();
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<string> availableLevels;
    private Dictionary<string, int> levelNameIndexDic;



    public int CurrentLevelIndex { get; private set; }

    private void Initialize()
    {
        levelNameIndexDic = new Dictionary<string, int>();
        for(int i = 0; i < availableLevels.Count; ++i)
        {
            Debug.Assert(!levelNameIndexDic.ContainsKey(availableLevels[i]),"Repeating level name: " + availableLevels[i]);
            levelNameIndexDic[availableLevels[i]] = i;
        }

        CurrentLevelIndex = levelNameIndexDic[SceneManager.GetActiveScene().name];
        //Debug.Log(CurrentLevelIndex);
    }

    public string GetLevelName(int index)
    {
        Debug.Assert(availableLevels != null && index >= 0 && index < availableLevels.Count,"Level With Index "+index+" Does Not Exist");
        return availableLevels[Mathf.Clamp(index,0,availableLevels.Count-1)];
    }


    public void LoadLevel(int index)
    {
        CurrentLevelIndex = index;
        SceneManager.LoadScene(GetLevelName(index));
    }

}
