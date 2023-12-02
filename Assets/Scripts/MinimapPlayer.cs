using System;
using System.Collections;
using System.Collections.Generic;
using Arcade;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class MinimapPlayer : MonoBehaviour
{
    [SerializeField] private RectTransform m_playerImage;
    [SerializeField] private RectTransform m_map;
    [SerializeField] private Vector3 bottomLeftCorner;
    [SerializeField] private Vector3 topRightCorner;
    
    private Vector3 m_playerPosition;    
    private Vector3 m_playerPositionOnMap;
    
    private Vector2 m_mapBottomLeftCorner;
    private Vector2 m_mapTopRightCorner;
    private void Start()
    {
        m_mapBottomLeftCorner = m_map.rect.center - (m_map.rect.size / 2);
        m_mapTopRightCorner = m_map.rect.center + (m_map.rect.size / 2);
    }
    
    private void Update()
    {
        m_playerPosition = transform.position;
        m_playerImage.anchoredPosition = GetPlayerPositionOnMap();
    }

    private Vector3 GetPlayerPositionOnMap()
    {
        m_playerPosition = transform.position;
        m_playerPositionOnMap.x = Mathf.Lerp(m_mapBottomLeftCorner.x, m_mapTopRightCorner.x, Mathf.InverseLerp(bottomLeftCorner.x, topRightCorner.x, m_playerPosition.x));
        m_playerPositionOnMap.y = Mathf.Lerp(m_mapBottomLeftCorner.y, m_mapTopRightCorner.y, Mathf.InverseLerp(bottomLeftCorner.z, topRightCorner.z, m_playerPosition.z));
        m_playerPositionOnMap.z = 0;
        return m_playerPositionOnMap;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Customer customer))
        {
            //If elimde yemek var mi
            //If elimdeki yemek musterinin siparisi ile ayni mi
            //Ayni ise musteriye yemegi ver
            //If musterinin siparisi alinmadiysa siparisi al
            Receipt todoList = customer.TakeReceipt();
        }
    }
}
