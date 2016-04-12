using System;
using System.Collections.Generic;

class LargeInt
{
    private bool isPositiveNumber = true;
    private List<byte> powList = new List<byte>(2);

    public bool IsPositive { get { return isPositiveNumber; } }
    public long Value { set { Set(value); } }

    private List<byte> Copy()
    {
        List<byte> copyList = new List<byte>(2);

        for (int i = 0; i < powList.Count; ++i)
        {
            copyList.Add(powList[i]);
        }

        return copyList;
    }

    public void Print()
    {
        string number = (isPositiveNumber?"":"-");

        for (int i = powList.Count - 1; i >= 0; --i)
        {
            number += powList[i];
        }
        Console.WriteLine(number);
    }

    public List<byte> GetRange(int index, int count)
    {
        List<byte> copyList = Copy();
        copyList.Reverse();

        return copyList.GetRange(index, count);
    }

    public void Set(string pSetNum)
    {
        powList.Clear();

        char[] arrNum = pSetNum.ToCharArray();

        for (int i = arrNum.Length - 1; i >= 0; --i)
        {
            byte num = 0;
            if (byte.TryParse(arrNum[i].ToString(), out num))
                powList.Add(num);
        }
    }

    public void Set(long pSetNum)
    {
        powList.Clear();

        isPositiveNumber = (pSetNum >= 0);

        ulong setNum = (ulong)(pSetNum * (isPositiveNumber ? 1 : -1));
        Unit.DivisionUnit divition = new Unit.DivisionUnit();

        while (setNum != 0)
        {
            divition.SetDivisionUnit(setNum, 10);

            powList.Add((byte)divition.Remainder);
            setNum = divition.Quotien;
        }

        CheckOver(powList);
    }

    public void Add(string pAddNum)
    {
        char[] arrNum = pAddNum.ToCharArray();

        for (int i = arrNum.Length - 1; i >= 0; --i)
        {
            int index = arrNum.Length - i - 1;
            byte num = 0;
            if (byte.TryParse(arrNum[i].ToString(), out num))
            {
                if (powList.Count <= index)
                {
                    powList.Add(0);
                }
                powList[index] += num;
            }
        }

        CheckOver(powList);
    }

    public void Add(long pAddNum)
    {
        bool isPositive = (pAddNum >= 0);
        bool isSamePositive = (isPositiveNumber == isPositive);

        ulong addNum = (ulong)(pAddNum * (isPositive ? 1 : -1));
        Unit.DivisionUnit divition = new Unit.DivisionUnit();

        int count = 0;
        while (addNum != 0)
        {
            divition.SetDivisionUnit(addNum, 10);

            if (powList.Count <= count)
            {
                isPositiveNumber = isPositive;
                powList.Add(0);
            }

            if(isSamePositive)
                powList[count] += (byte)divition.Remainder;
            else
                powList[count] -= (byte)divition.Remainder;
            
            addNum = divition.Quotien;
            ++count;
        }

        CheckOver(powList);
    }

    public void Add(List<byte> pAddList)
    {
        CheckOver(pAddList);
        for (int i = 0; i < pAddList.Count; ++i)
        {
            if (powList.Count <= i)
            {
                powList.Add(0);
            }

            powList[i] += pAddList[i];
        }
        CheckOver(powList);
    }

    public void Mul(long pMulNum)
    {
        bool isPositive = (pMulNum >= 0);
        isPositiveNumber = (isPositiveNumber == isPositive);

        ulong mulNum = (ulong)(pMulNum * (isPositive ? 1 : -1));
        Unit.DivisionUnit divition = new Unit.DivisionUnit();
        
        divition.SetDivisionUnit((ulong)byte.MaxValue, 10);
        ulong max = divition.Quotien;

        List<byte> lstMulNum = new List<byte>(2);
        while (mulNum != 0)
        {
            divition.SetDivisionUnit(mulNum, max);

            lstMulNum.Add((byte)divition.Remainder);
            mulNum = divition.Quotien;
        }

        List<byte> copyList = Copy();
        Set(0);

        List<byte> mulList = new List<byte>(2);
        for (int i = 0; i < lstMulNum.Count; ++i)
        {
            mulList.Clear();
            for (int j = 0; j < copyList.Count; ++j)
            {
                byte mulValue = (byte)(copyList[j] * lstMulNum[i]);
                mulList.Add(mulValue);
            }
            CheckOver(mulList);

            for (int z = 0; z < i; ++z)
            {
                for (int j = 0; j < copyList.Count; ++j)
                {
                    byte mulValue = (byte)(mulList[j] * max);
                    mulList[j] = mulValue;
                }
                CheckOver(mulList);
            }

            Add(mulList);
            CheckOver(powList);
        }
    }

    private void CheckOver(List<byte> lst)
    {
        byte num;
        byte overNum = 0;
        for (int j = 0; j < lst.Count; ++j)
        {
            lst[j] += overNum;
            num = lst[j];
            overNum = 0;
            if (num >= 10)
            {
                if (lst.Count <= j + 1)
                {
                    lst.Add(0);
                }

                overNum = (byte)(num / 10);
                num %= 10;
            }

            lst[j] = num;
        }
    }
}