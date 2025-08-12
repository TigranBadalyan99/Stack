
using System;
public class MyQueue<T>
{
    private T[] items;
    private int front;
    private int rear;
    private int count;
    private int capacity;

    public MyQueue(int size = 10)
    {
        capacity = size;
        items = new T[capacity];
        front = 0;
        rear = -1;
        count = 0;
    }

    public int Count => count;

    public bool IsEmpty()
    {
        return count == 0;
    }

    public bool IsFull()
    {
        return count == capacity;
    }

    public void Enqueue(T item)
    {
        if (IsFull())
        {
            Resize();
        }
        rear = (rear + 1) % capacity;
        items[rear] = item;
        count++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");

        T item = items[front];
        front = (front + 1) % capacity;
        count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");

        return items[front];
    }

    private void Resize()
    {
        int newCapacity = capacity * 2;
        T[] newItems = new T[newCapacity];

        for (int i = 0; i < count; i++)
        {
            newItems[i] = items[(front + i) % capacity];
        }

        items = newItems;
        front = 0;
        rear = count - 1;
        capacity = newCapacity;
    }

    public void Print()
    {
        Console.Write("Queue (front → rear): ");
        for (int i = 0; i < count; i++)
        {
            Console.Write(items[(front + i) % capacity] + " ");
        }
        Console.WriteLine();
    }
}
