using System;
using Merge;
using Unity.VisualScripting;
using UnityEngine;

//Abstract sınıflar miras alınmak için kullanılır. Herhangi bir oyun nesnesinin üzerine koyulamaz.
public abstract class CheatSheet : MonoBehaviour
{
    #region Variables

    //Public değerler her yerden erişilebilir.
    public int _publicInt;

    //Private değerler sadece tanımlandığı sınıf içerisinden erişilebilir.
    private int _privateInt;
    
    //SerializeField ile private değerler inspector üzerinden değiştirilebilir.
    [SerializeField] private int _privateIntWithSerializeField;

    //Protected değerler sadece tanımlandığı sınıf ve miras alan sınıflar içerisinden erişilebilir.
    protected int _protectedInt;
    
    private Action _action;

    #endregion

    //https://docs.unity3d.com/Manual/ExecutionOrder.html
    #region Unity Methods

    //Oyun basladığında script sahnede mevcut ise çalışır.
    private void Awake() {}
    
    //Awaketen sonra ve nesne aktif edildiğinde çalışır.
    private void OnEnable() {}

    //Oyun basladığında script sahnede aktif ise çalışır.
    private void Start() {}
    
    //Her frame başında çalışır.
    private void Update() {}

    //Unity'de ayarlanmış her fixed time stepte çalışır.
    private void FixedUpdate() {}

    //https://docs.unity3d.com/Manual/CollidersOverview.html
    //Bir nesne tarafından triggerlandığına çalışır.
    private void OnTriggerEnter(Collider other)
    {
        //Çarptığım nesne üzerinden scripte erişmek istiyorsam
        if (other.TryGetComponent(out CheatSheet cheatSheet))
        {
            
        }
        
        //Çarptığım nesne üzerinden script var mı diye kontrol etmek istiyorsam
        if (other.TryGetComponent(out CheatSheet _))
        {
            
        }
    }

    //Bir nesne tarafından triggerlanmaya devam ettiğinde çalışır.
    private void OnTriggerStay(Collider other) {}

    //Bir nesne tarafından triggerlanmaktan çıktığında çalışır.
    private void OnTriggerExit(Collider other) {}

    //Bir nesne tarafından temas edildiğinde çalışır.
    private void OnCollisionEnter(Collision other) {}

    //Bir nesne tarafından temas edilmeye devam edildiğinde çalışır.
    private void OnCollisionStay(Collision other) {}

    //Bir nesne tarafından temas edilmekten çıkıldığında çalışır.
    private void OnCollisionExit(Collision other) {}

    //Script disable edildiğinde çalışır.
    private void OnDisable() {}

    //Script destroy edildiğinde veya oyun kapatıldığında çalışır.
    private void OnDestroy() {}

    #endregion

    private void RaycastExample()
    {
        //Kamerayi awakete cachelemeyi unutmayin.
        Camera mainCamera = Camera.main;
        LayerMask layer = LayerMask.GetMask("MergeActor");
        
        //Mouse pozisyonunu raycast icin kullanabiliriz.
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            
        //Ray atarken mesafeyi ve layer belirtmeyi unutmayin.
        if (!Physics.Raycast(ray, out RaycastHit hit, mainCamera.farClipPlane, layer)) return;
            
        if (!hit.collider.TryGetComponent(out MergeActor actor)) return;
    }

    private void ActionExample()
    {
        //Actionlara method eklemek icin += kullanilir.
        _action += ActionMethod;

        //Actionlari direkt bir methoda setlemek icin = kullanilir.
        _action = ActionMethod;
        
        //Actionlari cagirmak icin Invoke kullanilir.
        _action?.Invoke();
    }

    private void ActionMethod()
    {
        Debug.Log("Debug action");
        Debug.LogWarning("Warning Action");
        Debug.LogError("Error Action");
    }
}