using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TomatoTree : MonoBehaviour
{
    [SerializeField] GameObject tomatoPrefab;
    [SerializeField] GameObject treeModel;
    [SerializeField] Transform[] Initslost;
    private List<GameObject> CloneTomato = new List<GameObject>();
    public float initRate = 2f;
    public int MaxTomato = 3;
    private int CurrentTomato = 0;
    private bool autoReduceTomato = false;
    private Transform parentAutoReduce = null;

    private void Start()
    {
        if (CurrentTomato < MaxTomato) {
            InvokeRepeating(nameof(ProgressInitTomato), initRate, initRate);
        }
    }

    private void ProgressInitTomato() {
        GameObject _tomato = Instantiate(tomatoPrefab);
        CurrentTomato++;
        _tomato.transform.parent = Initslost[CurrentTomato - 1];
        _tomato.transform.localPosition = Vector3.zero;
        _tomato.transform.localScale = Vector3.one * 0.01111111f;
        CloneTomato.Add(_tomato);
        Vector3 startScale = treeModel.transform.localScale;
        treeModel.transform.DOScale(new Vector3(startScale.x, startScale.y * 1.2f, startScale.z), 0.2f).OnComplete(() => {
            treeModel.transform.DOScale(new Vector3(startScale.x, startScale.y * 0.9f, startScale.z), 0.2f).OnComplete(() => {
                treeModel.transform.DOScale(new Vector3(startScale.x, startScale.y * 1.15f, startScale.z), 0.2f).OnComplete(() => {
                    treeModel.transform.DOScale(new Vector3(startScale.x, startScale.y * 0.95f, startScale.z), 0.2f).OnComplete(() => {
                        treeModel.transform.DOScale(new Vector3(startScale.x, startScale.y * 1.05f, startScale.z), 0.2f).OnComplete(() => {
                            treeModel.transform.DOScale(new Vector3(startScale.x, startScale.y * 0.98f, startScale.z), 0.2f).OnComplete(() => {
                                treeModel.transform.DOScale(startScale, 0.2f);
                            });
                        });
                    });
                });
            });
        });
        if (autoReduceTomato && parentAutoReduce) {
            ReduceTomato(parentAutoReduce);
        }
        if (CurrentTomato == MaxTomato) {
            CancelInvoke(nameof(ProgressInitTomato));
        }
    }

    public void ReduceTomato(Transform newParent = null) {
        if (CurrentTomato > 0) {
            CurrentTomato--;
            GameObject tomatoRemove = CloneTomato[CloneTomato.Count - 1];
            CloneTomato.Remove(tomatoRemove);
            if (newParent != null) {
                tomatoRemove.transform.parent = newParent;
            }
            else {
                Destroy(tomatoRemove.gameObject);    
            }
            if (!IsInvoking(nameof(ProgressInitTomato))) {
                InvokeRepeating(nameof(ProgressInitTomato), initRate, initRate);
            }
        }   
    }

    public void ReduceAlltomato(Transform newParent = null) {
        for (int i = 0; i < MaxTomato;i++) {
            ReduceTomato(newParent);
        }
        
    }

    public void SetAutoReduceTomato(bool _auto,Transform newParent = null) {
        autoReduceTomato = _auto;
        parentAutoReduce = newParent;
    }
}
