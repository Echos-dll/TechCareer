using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class RefValue : MonoBehaviour
    {
        private List<int> intList = new List<int>();
        private List<int> tempList = new List<int>();

        private int val1;
        private int val2;

        struct Mystruct
        {
            public List<int> list;
        }
        
        private void Start()
        {
            Mystruct struct1 = new Mystruct();
            Mystruct struct2 = new Mystruct();

            struct1.list = new List<int>();
            struct2.list = new List<int>();
            
            intList.Add(1);
            intList.Add(2);
            intList.Add(3);
            intList.Add(4);
            
            struct1.list = intList;
            struct2.list = tempList;
            
            struct2 = struct1;
            
            struct2.list.RemoveAt(0);
            struct2.list.RemoveAt(0);

            Debug.Log("struct1.list.Count: " + struct1.list.Count);
            Debug.Log("struct2.list.Count: " + struct2.list.Count);


            // intList.Add(1);
            // intList.Add(2);
            // intList.Add(3);
            // intList.Add(4);
            //
            // tempList = new List<int>(intList);
            //
            // intList.RemoveAt(0);
            // intList.RemoveAt(1);
            //
            // foreach (int i in tempList)
            // {
            //     Debug.Log(i);
            // }
            //
            // val1 = 5;
            // val2 = 10;
            //
            // val1 = val2;
            //
            // val2--;
            // Debug.Log(val1);
        }
    }
}