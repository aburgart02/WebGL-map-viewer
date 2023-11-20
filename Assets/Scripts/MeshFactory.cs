using UnityEngine;

public class MeshFactory
{
    private const string ChunkMeshRendererPath = "Chunk";

    public GameObject CreateChunkMeshRender(Vector3 position, Quaternion rotation, Transform parent)
    {
        var chunkMeshRenderer = Resources.Load<GameObject>(ChunkMeshRendererPath);
        return Object.Instantiate(chunkMeshRenderer, position, rotation, parent);
    }
}