using System.Collections.Generic;
using UnityEngine;

public class SceneLoder : MonoBehaviour
{
    [SerializeField]private List<int> SceneIndexs;
    private List<int> SceneIndexsTemp;
    [SerializeField]private Door[] doors;
    private void Awake()
    {
        SceneIndexsTemp = SceneIndexs;
        for (int i = 0; i < 2; i++) 
        {
            int rand = Random.Range(0, SceneIndexsTemp.Count);
            doors[i].sceneIndex = SceneIndexsTemp[rand];
            SceneIndexsTemp.RemoveAt(rand);
        }
    }
}
