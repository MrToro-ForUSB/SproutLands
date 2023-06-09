using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected abstract void Move();
    protected abstract void DeleteEntity(params object[] arguments);
}
