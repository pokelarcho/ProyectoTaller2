using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineShake : MonoBehaviour
{
    public static CineMachineShake Instance { get; private set; }
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shaketimer;
    // Start is called before the first frame update
    public void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shaketimer= time;
    }

    private void Update()
    {
        if (shaketimer > 0) { 
        shaketimer -= Time.deltaTime;
        if (shaketimer <= 0f) {
            //Time over!
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
              cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
          }
        }
    }
}
