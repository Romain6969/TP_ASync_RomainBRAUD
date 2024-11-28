using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSquare : MonoBehaviour
{
    [SerializeField] private GameObject _square;
    private bool _start = false;

    public void OnClickButtonRotate()
    {
        _start = true;
    }

    public void OnClickButtonStop()
    {
        _start = false;
    }

    private void Update()
    {
        if (!_start)
        {
            StopAllCoroutines();
            return;
        }
        
        StartCoroutine(CoroutineRotate());
    }

    private IEnumerator CoroutineRotate()
    {
        _square.transform.Rotate(0, 0, 1);
        yield return new WaitForSeconds(5);
        _start = false;
    }
}
