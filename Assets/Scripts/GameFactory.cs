using UnityEngine;

public class GameFactory
{ 
    public GameObject CreateGameObjectContainer(string containerName)
    {
        return new GameObject(containerName);
    }
}