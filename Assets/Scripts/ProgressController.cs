using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour {

    // Use this for initialization
    Image progress;
    float progressLoadingTime = 60f;
    Coroutine loading;

    private void Awake()
    {
        progress = GetComponent<Image>();
    }
    private void OnEnable()
    {
        loading = StartCoroutine("Countdown");
    }

    private IEnumerator Countdown()
    {
        float duration = 1.5f; // 3 seconds you can change this to
                             //to whatever you want
        float totalTime = 0;
        while (totalTime <= duration)
        {
            progress.fillAmount = totalTime / duration;
            totalTime += Time.deltaTime;
            yield return null;
        }
    }

    private void OnDisable()
    {
        StopCoroutine(loading);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
