using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchConfiner : MonoBehaviour
{
    [SerializeField] CinemachineConfiner confiner;
    [SerializeField] PolygonCollider2D[] colliders;

    private int currentColliderIndex = 0;

    private void Update()
    {
        // Check if the player has entered a new area
        if (colliders[currentColliderIndex].OverlapPoint(transform.position))
        {
            // Switch to the next collider
            currentColliderIndex = (currentColliderIndex + 1) % colliders.Length;
            confiner.m_BoundingShape2D = colliders[currentColliderIndex];
        }
    }
}

