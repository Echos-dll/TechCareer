using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveSystem
{
    public class SaveMe : MonoBehaviour
    {
        [SerializeField] private Data _data;
        
        [Button]
        public void Save()
        {
            string data = JsonUtility.ToJson(_data);
            PlayerPrefs.SetString("Save", data);
            Debug.Log("Data saved. Data: \n" + data);
        }

        [Button]
        public void Load()
        {
            string data = PlayerPrefs.GetString("Save", String.Empty);
            if (data == String.Empty)
            {
                Debug.Log("No save data found");
                return;
            }

            Data savedClass = JsonUtility.FromJson<Data>(data);
            
            _data._id = savedClass._id;
            _data._name = savedClass._name;
            _data._floatValue = savedClass._floatValue;
            _data._intArray = savedClass._intArray;
            _data._vector3 = savedClass._vector3;
            _data._testDataList = savedClass._testDataList;
        }
    }

    [Serializable]
    public struct TestData
    {
        public int testInt;
        public string testString;
    }

    [Serializable]
    public class Data
    {
        public int _id;
        public string _name;
        public float _floatValue;
        public int[] _intArray;
        public Vector3 _vector3;
        public List<TestData> _testDataList;
    }
}