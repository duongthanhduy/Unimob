using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    bool stayTomatoTree = false;
    private TomatoTree currenttomatoTree = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tomatotree")) {
            stayTomatoTree = true;
            TomatoTree tomatoTree = other.GetComponent<TomatoTree>();
            tomatoTree.ReduceAlltomato();
            currenttomatoTree = tomatoTree;
            tomatoTree.SetAutoReduceTomato(true,transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("tomatotree"))
        {
            stayTomatoTree = false;
            TomatoTree tomatoTree = other.GetComponent<TomatoTree>();
            if (currenttomatoTree && currenttomatoTree == tomatoTree) {
                currenttomatoTree = null;
                tomatoTree.SetAutoReduceTomato(false, null);
            }
        }
    }
}
