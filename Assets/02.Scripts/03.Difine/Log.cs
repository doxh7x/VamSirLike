#if Log
using UnityEngine;

public class static Log : MonoBehaviour
{
    public void Message(string message)
    {
        Debug.Log(message);
    }
}

#endif
