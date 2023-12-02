using System;
using UnityEngine;

namespace Shaders
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class MeshGenerator : MonoBehaviour
    {
        private Mesh m_mesh;
        
        private MeshFilter m_meshFilter;
        private MeshRenderer m_meshRenderer;

        private void Awake()
        {
            m_meshFilter = GetComponent<MeshFilter>();
            m_meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            m_mesh = new Mesh();
            m_mesh.name = "My Generated Mesh";
            
            m_mesh.vertices = new Vector3[]
            {
                new Vector3(0, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(1, 1, 0),
                new Vector3(1, 0, 0)
            };
            
            m_mesh.triangles = new int[]
            {
                0, 1, 2,
                0, 2, 3
            };
            
            m_mesh.normals = new Vector3[]
            {
                Vector3.back,
                Vector3.back,
                Vector3.back,
                Vector3.back
            };
            
            

            m_meshFilter.mesh = m_mesh;
        }
    }
}
