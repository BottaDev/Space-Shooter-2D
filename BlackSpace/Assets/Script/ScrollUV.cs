using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    public float scrollSpeed = 1f;   // CUIDADO

    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x += Time.deltaTime / scrollSpeed;

        mat.mainTextureOffset = offset;
    }
}
