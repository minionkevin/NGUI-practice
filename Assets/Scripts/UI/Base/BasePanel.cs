using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//singleton
public abstract class BasePanel<T>: MonoBehaviour where T:class
{

    private static T instance;
    public static T Instance => instance;

    
    //inheirted class can rewrite
    protected virtual void Awake()
    {
        instance = this as T;
    }

    protected virtual void Start()
    {
        //btn listenner
        init();
    }

    public abstract void init();

    public virtual void show()
    {
        this.gameObject.SetActive(true);
    }
    public virtual void hide()
    {
        this.gameObject.SetActive(false);
    }
}
