using System.Collections.Generic;
using UnityEngine;

public class TAccessor<T> where T : EntityModule, new() 
{
    public static TAccessor<T> Instance()
    {
        if (_singleton == null)
        {
            _singleton = new TAccessor<T>();
            _modules = new List<T>();
        }

        return _singleton;
    }

    private static TAccessor<T> _singleton = null;
    //private static List<TAccessor<T>> _accessors;
    private static List<T> _modules;
    
    /*private void Awake()
    {
        _singleton = new TAccessor<T>();
        _modules = new List<T>();
    }*/

    public List<T> GetAllModules()
    {
        return _modules;
    }

    public void Add(T moduleInstance)
    {
        _modules.Add(moduleInstance);
    }

    public void CreateModules(List<GameObject> objs)
    {
        int nb = objs.Count;
        for (int i = 0; i < nb; i++)
        {
            T newModule = new T();
            newModule.gameObject = objs[i];
            Add(newModule);
        }
    }

    public void CreateModule(GameObject obj)
    {
        T newModule = new T();
        newModule.gameObject = obj;
        Add(newModule);
    }

    public GameObject GetGameObject(int index)
    {
        if (index >= _modules.Count)
        {
            return null;
        }
        return _modules[index].gameObject;
    }

    public T GetModule(int index)
    {
        return _modules[index];
    }

    public void RemoveModule(int index)
    {
        T module = _modules[index];
        _modules.RemoveAt(index);
        module.gameObject.SetActive(false);
    }
}