using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour{

    private static T instance;
    public static T Instance
    {
        get{
            if (instance != null) return instance;
            var t = typeof(T);

            instance = (T)FindObjectOfType (t);
            if (instance == null) {
                Debug.LogError (t + " is not attached to any GameObject");
            }

            return instance;
        }
    }

    protected virtual void Awake(){
        CheckInstance();
    }

    private bool CheckInstance(){
        if (instance == null) {
            instance = this as T;
            return true;
        }

        if (Instance == this) {
            return true;
        }
        Destroy (this);
        return false;
    }
}