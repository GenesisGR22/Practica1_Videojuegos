using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBalaC : MonoBehaviour
{
    private int Balas = 5;
    public Text BalaC;

    public int GetBala()
    {
        return Balas;
    }

    public void QuitarBala(int Balas)
    {
        this.Balas -= Balas;
        BalaC.text = "" + GetBala();
    }
}
