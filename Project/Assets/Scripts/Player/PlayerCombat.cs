using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool TryAttack(Color attackColor, Enemy enemy)
    {
        if (enemy && attackColor == enemy.GetColor)
        {
            enemy.Kill();
            return true;
        }

        return false;
    }
}
