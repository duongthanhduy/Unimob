using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private string _move = "IsMove";
    private string _carryMove = "IsCarryMove";
    private string _empty = "IsEmpty"; 
    [SerializeField] Animator anim;
    public void EmptyMove()
    {
        anim.SetBool(_move,true);
    }

    public void IdleEmty() {
        anim.SetBool(_move, false);
        anim.SetBool(_empty, true);
    }

    public void CarryMove() {
        anim.SetBool(_empty, false);
    }
    public void CarryIdle() {
        anim.SetBool(_carryMove, false);
    }
}
