using DG.Tweening;
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
        WIndowsLinker wIndowsLinker = new();
        AddSubManager<UIManager>("UIManager");
        AddSubManager<GameManager>("GameManager");
        AddSubManager<SpawnManager>("SpawnManager");
        AddSubManager<CursorControllor>("CursorControllor");

        DOTween.SetTweensCapacity(1000, 50);

        WIndowsLinker.instance.PuaseGame += PuasrTime;
        WIndowsLinker.instance.ExitGame += QuitGame;

        //WIndowsLinker.instance.OpenStartWindows.Invoke(true);
    }

    public void RemoveSubManager<T>() where T : MonoBehaviour
    {

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

    void PuasrTime(bool isPuase)
    {
        Time.timeScale = isPuase ? 0 : 1;
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
