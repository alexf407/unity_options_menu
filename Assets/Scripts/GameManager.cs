using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 18 - stereo
// 

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public ConfigFile cfg;
    [SerializeField] GameObject[] Managers;
    List<GameObject> _instantiatedManagers = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();
        InstantiateManagers();
    }

    void InstantiateManagers()
    {
        for (int i = 0; i < Managers.Length; ++i)
        {
            _instantiatedManagers.Add(Instantiate(Managers[i]));
        }
    }

    public void QuitGame()
    {
        // Destroy managers in reverse order to correctly remove event listeners
        for (int i = _instantiatedManagers.Count - 1; i >= 0; --i)
        {
            Destroy(_instantiatedManagers[i]);
        }

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
