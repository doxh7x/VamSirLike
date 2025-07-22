using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using static EnumDifine;

public class Player : MonoBehaviour
{
    public int hp { get; private set; }
    public float moveSpeed { get; private set; }

    private int mAtk;

    public Dictionary<AtkReason, int> AtkReasonDictionary = new Dictionary<AtkReason, int>();

    public int Atk
    {
        get
        {
            mAtk = 0;
            foreach (var item in AtkReasonDictionary)
            {
                mAtk += item.Value;
            }
            return mAtk;
        }
    }

    public void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            transform.position += Vector3.up * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.position += Vector3.down * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
    }

    public void AddAtkPoint(int value)
    {
        moveSpeed += value;
    }

    public void MinusAtkPoint(int value)
    {
        moveSpeed -= value;
    }

    public void AddAtkReason(AtkReason reason, int value)
    {
        if (AtkReasonDictionary.TryAdd(reason, value) == false)
        {
            AtkReasonDictionary[reason] += value;

            Log.Message($"공격력 수치 변화 : {reason}, {value}.");
        }
    }
}
