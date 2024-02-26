namespace SimpleArray;

public class MyArray
{
    private readonly int[] _myArr;

    public int[] Array => _myArr;

    public MyArray(int size)
    {
        _myArr = Enumerable.Range(0, size).ToArray();
    }

    public bool Replace(int position, int newValue)
    {
        if (position < 0)
        {
            throw new ArgumentException("Position must not be less than zero");
        }

        if (position >= _myArr.Length)
        {
            throw new ArgumentException("Position must be valid");
        }

        _myArr[position] = newValue;
        return true;
    }

    public int FindMax()
    {
        if (_myArr.Length == 0)
        {
            throw new InvalidOperationException("Array is empty");
        }

        return _myArr.Max();
    }
}
