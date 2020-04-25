using UnityEngine;

// This class will provide a function that can be called to instantiate a gameobject. You can call the function from a UnityEvent. 
public class InstantiateGameObject : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    public void InstantiateGO()
    {
        Instantiate(gameObjectToInstantiate, transform.position, Quaternion.identity);
    }
}
