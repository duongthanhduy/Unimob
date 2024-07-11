using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] PlayerAnim playerAnim;
    Stack<GameObject> Tomato = new Stack<GameObject>();
    public PlayerStatus PlayerStatus { get;private set;} = PlayerStatus.EmptyIdle;

    private void Start()
    {
        IdleEmty();
    }

    public void Move()
    {
        if (Tomato.Count == 0) {
            SetStatus(PlayerStatus.MoveEmpty);
            playerAnim.EmptyMove();
        }
        else{
            SetStatus(PlayerStatus.CarryMove);
            playerAnim.CarryMove();
        }
    }

    public void StopMove() {
        if (PlayerStatus == PlayerStatus.MoveEmpty) {
            SetStatus(PlayerStatus.EmptyIdle);
            playerAnim.IdleEmty();
        }
        else if (PlayerStatus == PlayerStatus.CarryMove) {
            SetStatus(PlayerStatus.CarryIdle);
            playerAnim.CarryIdle();
        }
    }

    public void IdleEmty()
    {
        SetStatus(PlayerStatus.EmptyIdle);
        playerAnim.IdleEmty();
    }

   

    public void SetStatus(PlayerStatus _status) {
        if (_status != PlayerStatus) {
            PlayerStatus = _status;
        } 
    }
}
public enum PlayerStatus {
    EmptyIdle = 0,
    MoveEmpty = 1,
    CarryIdle = 2,
    CarryMove = 3,

}
