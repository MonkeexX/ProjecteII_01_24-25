using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    public void Turn()
    {
        SceneManager.LoadScene(0);
    }
}
