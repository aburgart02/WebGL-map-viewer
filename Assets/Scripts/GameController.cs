using System.Collections;
using System.IO;
using MapLogic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : MonoBehaviour
{
    private IEnumerator Start()
    {
        var gameFactory = new GameFactory();
        var meshFactory = new MeshFactory();
        using UnityWebRequest webRequest =
            UnityWebRequest.Get($"http://localhost:8080/download-map-file/{Application.absoluteURL.Split('=')[1]}");
        yield return webRequest.SendWebRequest();

        var bytes = webRequest.downloadHandler.data;

        using var binaryMap = new MemoryStream(bytes);
        var mapData = MapReader.ReadFromStream(binaryMap);
        var mapProvider = new MapProvider(mapData);
        var mapGenerator = new MapGenerator(mapProvider, gameFactory, meshFactory);
        mapGenerator.GenerateMap();
    }
}