using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Material Settings", menuName = "ScriptableObjects/Material Settings", order = 0)]
    public class MaterialSettings : ScriptableObject
    {
        public Material[] _materials;
    }
}