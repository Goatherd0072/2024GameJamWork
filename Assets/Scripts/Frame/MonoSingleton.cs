
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _inst = null;

    public static T instance
    {
        get
        {
            return _inst;
        }
    }

    protected virtual void Awake()
    {
        _inst = (T)this;
    }
}
