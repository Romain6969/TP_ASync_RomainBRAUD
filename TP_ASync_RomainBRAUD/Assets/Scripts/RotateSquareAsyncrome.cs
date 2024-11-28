using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateSquareAsyncrome : MonoBehaviour
{
    [SerializeField] private GameObject _square;
    private bool _start = false;
    private bool _stop = false;
    private List<Task> _tasks;

    async Task Rotate()
    {
        if (_stop == false) // pour que ca ne faissent le delay qu'une seul foit et que une fois terminer il arrete la rotation
        {
            _stop = true;
            await Task.Delay(5000);
            _start = false;
            _stop = false;
        }
        else
        {
            _square.transform.Rotate(0, 0, 1);
        }
    }

    public void OnClickButtonRotate()
    {
        _start = true;
    }

    public void OnClickButtonStop()
    {
        _start = false;
        _tasks = null;
    }

    private void Update()
    {

        if (!_start)
        {
            return;
        }

        //Ceci me premet de commencer la fonction rotate
        _tasks = new()
        {
            Rotate(),
        };

        //Task.CompletedTask.Wait();
        //mais ce task.whenall me fait une boucle infinie
        //Task.WhenAny(_tasks).Wait();
    }
}
