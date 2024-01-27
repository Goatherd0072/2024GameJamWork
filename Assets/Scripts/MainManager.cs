using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoSingleton<MainManager>
{
    //Dictionary<string, MonoBehaviour> _managerDic = new Dictionary<string, MonoBehaviour>();

    new void Awake()
    {
        AddSubManager<UIManager>("UIManager");
        AddSubManager<GameManager>("GameManager");
        AddSubManager<SpawnManager>("SpawnManager");
        AddSubManager<CursorControllor>("CursorControllor");
    }

    void AddSubManager<T>(string name) where T : MonoBehaviour, new()
    {
        GameObject go = null;
        foreach (var item in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            if (item.name == name)
            {
                go = item;
                break;
            }
        };

        if (go == null)
        {
            GameObject subManager = new GameObject(name);
            subManager.AddComponent<T>();
        }
        else
        {
            go.SetActive(true); 
        }
    }

}
