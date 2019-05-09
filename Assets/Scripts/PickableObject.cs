using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour {

    Coroutine loading;

    public void OnGaze()
    {
        loading = StartCoroutine("Countdown");
    }

    public void StopGaze()
    {
        StopCoroutine(loading);
    }
    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1.6f);
        Destroy(this.gameObject);
    }

    private void PickObject()
    {
        //Destroy(this);
    }

}
