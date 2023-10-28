using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    //Button Controller script pull test
    [SerializeField] private Image m_Image;

    private Button m_button;
    
    private void Awake()
    {
        m_button = GetComponent<Button>();
    }

    private void ImageToggle()
    {
        m_Image.gameObject.SetActive(!m_Image.gameObject.activeInHierarchy);
    }

    private void OnEnable()
    {
        m_button.onClick.AddListener(ImageToggle);
    }

    private void OnDisable()
    {
        m_button.onClick.RemoveListener(ImageToggle);
    }
}
