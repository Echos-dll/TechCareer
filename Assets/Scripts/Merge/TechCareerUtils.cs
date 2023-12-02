using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Editor
{
    public static class TechCareerUtils
    {
//         [MenuItem("Tools/TechCareer/Load EditorTools Level")]
//         private static void denemetest()
//         {
//             EditorSceneManager.OpenScene("Assets/Scenes/EditorTools.unity");
//         }
// //         % – CTRL on Windows / CMD on OSX
// //         # – Shift
// //         & – Alt
// //         LEFT/RIGHT/UP/DOWN – Arrow keys
// //         F1…F2 – F keys
// //         HOME, END, PGUP, PGDN
//         
//         [MenuItem("Tools/TechCareer/Print Message %#p")]
//         private static void PrintMessage()
//         {
//             Debug.Log("Test");
//         }

        private static PointerEventData s_eventDataCurrentPosition;
        private static List<RaycastResult> s_results;
        
        public static void AddPositionX(this Transform t, float value)
        {
            Vector3 p = t.position;
            p.x += value;
            t.position = p;
        }

        public static void AddPositionY(this Transform t, float value)
        {
            Vector3 p = t.position;
            p.y += value;
            t.position = p;
        }

        public static void AddPositionZ(this Transform t, float value)
        {
            Vector3 p = t.position;
            p.z += value;
            t.position = p;
        }
        
        public static bool IsOverUI()
        {
            s_eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
            s_results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(s_eventDataCurrentPosition, s_results);
            return s_results.Count > 0;
        }
        
        public static GameObject UIRaycast (PointerEventData pointerData)
        {
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
 
            return results.Count < 1 ? null : results[0].gameObject;
        }
    }
}