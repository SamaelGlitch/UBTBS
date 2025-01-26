using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public GameObject[] boobaOptions;
    public GameObject[] teaOptions;

    public void SelectBooba(int index)
    {
        for (int i = 0; i < boobaOptions.Length; i++)
        {
            boobaOptions[i].SetActive(i == index);
        }
    }

    public void SelectTea(int index)
    {
        for (int i = 0; i < teaOptions.Length; i++)
        {
            teaOptions[i].SetActive(i == index);
        }
    }
}