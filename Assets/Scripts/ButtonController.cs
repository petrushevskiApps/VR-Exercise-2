using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    // Use this for initialization
    //[SerializeField]
    private const float COUNTDOWN_DURATION = 5f;

    public GameObject projectorGlobe;
    public ParticleSystem projectorParticles;
    public Image progress;

    private Coroutine countdown;
    private Coroutine changeState;

    private void Awake()
    {
        projectorParticles.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
		
	}

    public void OnGaze(bool state)
    {
        countdown = StartCoroutine(ChangeState(state));
    }

    public void StopGaze()
    {
        StopAllCoroutines();
        progress.fillAmount = 0;
    }
    private IEnumerator ChangeState(bool state) 
    {
        yield return StartCoroutine(Countdown(state));

        projectorGlobe.SetActive(state);
        projectorParticles.gameObject.SetActive(state);
    }

    private IEnumerator Countdown(bool state)
    {
        float totalTime = 0;
        while (totalTime <= COUNTDOWN_DURATION)
        {
            progress.fillAmount = totalTime / COUNTDOWN_DURATION;
            totalTime += Time.deltaTime;
            yield return null;
        }
    }
}
