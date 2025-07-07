using JetBrains.Annotations;
using UnityEngine;

public class BookButton : MonoBehaviour
{
    [SerializeField] private Computer computer;
    public void Book()
    {
        computer.OpenSuccessScreen();
        
    }
}
