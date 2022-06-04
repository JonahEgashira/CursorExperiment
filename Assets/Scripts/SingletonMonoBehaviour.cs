using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour{

    private static T _instance;
    public static T Instance
    {
        get{
            if (_instance != null) return _instance;
            var t = typeof(T);

            _instance = (T)FindObjectOfType (t);
            if (_instance == null) {
                Debug.LogError (t + " is not attached to any GameObject");
            }

            return _instance;
        }
    }

    protected virtual void Awake(){
        CheckInstance();
    }

    private bool CheckInstance(){
        if (_instance == null) {
            _instance = this as T;
            return true;
        }

        if (Instance == this) {
            return true;
        }
        Destroy (this);
        return false;
    }
}