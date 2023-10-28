using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Image m_image;
    private Button m_button;
    
    private void Awake()
    {
        m_button = GetComponent<Button>();
    }

    private void ImageToggle()
    {
       m_image.gameObject.SetActive(!m_image.gameObject.activeInHierarchy);
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
