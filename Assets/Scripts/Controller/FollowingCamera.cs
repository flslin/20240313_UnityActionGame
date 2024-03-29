﻿using UnityEngine;

/// <summary>
/// 카메라가 일정거리를 유지한 채로 플레이어를 추적하는 기능
/// </summary>
class FollowingCamera :MonoBehaviour
{
    public float distanceAway = 7.0f;
    public float distanceUp = 4.0f;

    public Transform follow;

    // Unity 처리가 끝났을 때 호출하는 라이프 사이클
    private void LateUpdate()
    {
        // 카메라 위치를 distanceUp만큼 위로, distanceAway만큼 앞에 위치
        transform.position = follow.position + Vector3.up * distanceUp - Vector3.forward * distanceAway;
    }
}

