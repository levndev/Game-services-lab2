using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class DragonPicker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TestText;
    [SerializeField] private UnityEvent authorizationCheck;
    public GameObject EnergyShieldPrefab;
    public int EnergyShieldAmount = 3;
    public float EnegyShieldBottomY = -6;
    public float EnegyShieldRadius = 1.5f;
    private bool FirstLaunch = true;
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 1; i <= EnergyShieldAmount; i++)
        {
            var tShieldGo = Instantiate(EnergyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, EnegyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(1 * i, 1 * i, 1 * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


    public void ResolvedAuthorization()
    {
        TestText.text = $"SDK подключен. Игрок : \"{YandexGame.playerName}\"";
        Console.WriteLine(YandexGame.playerName);
    }

    public void RejectedAuthorization()
    {
        TestText.text = $"SDK подключен. Авторизация провалена";
    }

    private void OnEnable() => YandexGame.GetDataEvent += SdkDataReceived;

    private void OnDisable() => YandexGame.GetDataEvent -= SdkDataReceived;

    private void SdkDataReceived()
    {
        if (YandexGame.SDKEnabled && FirstLaunch)
        {
            TestText.text = $"SDK подключен. Авторизация...";
            authorizationCheck?.Invoke();
            FirstLaunch = false;
        }
    }
}
