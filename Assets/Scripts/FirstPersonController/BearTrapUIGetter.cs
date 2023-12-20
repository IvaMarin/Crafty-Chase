using UnityEngine;
using UnityEngine.UI;


// This class simply gives a pointer to a part of player's UI.
// 
[RequireComponent(typeof(FirstPersonController))]
public class BearTrapUIGetter : MonoBehaviour
{
    [SerializeField] Slider progressBar;

    public Slider GetProgressBar()
    {
        return progressBar;
    }
}
