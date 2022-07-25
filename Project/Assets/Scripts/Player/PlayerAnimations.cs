using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string sucsess_key;
    [SerializeField] private string wrong_key;

    public void SetSucsess() => animator.SetTrigger(sucsess_key);
    public void SetWrong() => animator.SetTrigger(wrong_key);
}
