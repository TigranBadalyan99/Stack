
using System;

public class MyStack<T>
{
    private T[] items;
    private int top;
    private int capacity;

    public MyStack(int size = 10)
    {
        capacity = size;
        items = new T[capacity];
        top = -1;
    }

    public int Count => top + 1;

    public bool IsEmpty()
    {
        return top == -1;
    }

    public bool IsFull()
    {
        return top == capacity - 1;
    }

    public void Push(T item)
    {
        if (IsFull())
        {
            Resize();
        }
        items[++top] = item;
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty");

        return items[top--];
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty");

        return items[top];
    }

    private void Resize()
    {
        capacity *= 2;
        T[] newItems = new T[capacity];
        Array.Copy(items, newItems, top + 1);
        items = newItems;
    }

    public void Print()
    {
        Console.Write("Stack (top → bottom): ");
        for (int i = top; i >= 0; i--)
        {
            Console.Write(items[i] + " ");
        }
        Console.WriteLine();
    }
}