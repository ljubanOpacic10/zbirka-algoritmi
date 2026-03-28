<Query Kind="Program" />

void Main()
{

}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1 - Heap Sort
// -----------------------------------------------------
public class HeapSort
{
	// -----------------------------------------------------
	public static void sort(long[] arr)  
	{

	}
	// -----------------------------------------------------
}

public class Heap
{
	private int[] array;
	private const int Capacity = 32;
	private int count;
	private bool isMinHeap;
	
	public Heap(bool isMin = true)
	{
		array = new int[Capacity];
		count = 0;
		isMinHeap = isMin;
	}
	
	public Heap(int[] array, bool isMin = true)
	{
		count = array.Length;	
		this.array = new int[array.Length];
		Array.Copy(array, 0, this.array, 0, array.Length); 
		isMinHeap = isMin;
		
		buildHeap();
	}
	
	public void print()
	{
		for(int i = 0; i < size(); i++)
			Console.Write(array[i] + " ");
	}
	
	public int size()
	{
		return count;
	}
	
	private void buildHeap()
	{
		for (int i = count/2; i >= 0; i--)
		{
			heapify(i);
		}
	}
	
	public void add(int value)
	{
		if (count == array.Length)
		{
			doubleSize();
		}
		
		array[count++] = value;
		
		buildHeap();
	}
	
	private void doubleSize()
	{
		int[] old = array;
		array = new int[array.Length * 2];
		Array.Copy(old, 0, array, 0, count);
	}
	
	public int? remove()
	{
		if (count == 0)
			return null;
			
		int value = array[0];
		array[0] = array[count - 1];
		count--;
		heapify(0);
		return value;
	}
	
	private void heapify(int parent)
	{
		int leftChild = 2 * parent + 1;
		int rightChild = leftChild + 1;
		int child = -1;
		int temp;				
		
		if (leftChild < count)
		{
			child = leftChild;
		}
		
		if (rightChild < count && compare(array, leftChild, rightChild))
		{
			child = rightChild;
		}
		
		if (child != -1 && compare(array, parent, child))
		{
			temp = array[parent];
			array[parent] = array[child];
			array[child] = temp;
			heapify(child);
		}
	}
	
	private bool compare(int[] arr, int first, int second)
	{
		if (isMinHeap)
		{
			return (array[first] - array[second]) > 0;
		}
		else
		{
			return (array[second] - array[first]) > 0;
		}
	}
}

public class RandomArrayGenerator
{	
	public long[] GenerateRandomArray(long n)
	{
		RandomNumberGen random = new RandomNumberGen();
		long[] randomArray = new long[n];
		
		for(int i = 0; i < n; i++)
		{			
			randomArray[i] = random.Next();
		}		
		return randomArray;
	}
}

public class RandomNumberGen
{
	private long mod = 4294967296;
    private const long a = 214013;
    private const long c = 2531011;
	private long min = 0;
	private long max = 100;
    private double seed;
	
	public RandomNumberGen()
	{
		seed = (long)DateTime.Now.Ticks % mod;
	}
	
	public RandomNumberGen(long min, long max) : this()
	{
		this.min = min;
		this.max = max;
	}
	
	public long Next()
	{
		seed = ((a * seed) + c) % mod;
		return (long)((seed / (mod - 1)) * (max - min) + min);
	}
}
// -----------------------------------------------------



// ZADATAK 2 – Kumulativna suma vrednosti levih suseda 
// -----------------------------------------------------
public class LinkedList
{
	
	private class Node
	{
		internal int value;
		internal Node next;
		
		public Node(int v, Node n)
		{
			value = v;
			next = n;
		}
	}
	
	private Node head;
	private int count = 0;
	
	// -----------------------------------------------------
	public void calculateCumulativeSum() 
	{
	
	}
	// -----------------------------------------------------
	
	
	public void addHead(int value)
	{
		head = new Node(value, head);
		count++;
	}
	
	public void addTail(int value)
	{
		Node newNode = new Node(value, null);
		Node curr = head;
		
		if (head == null)
		{
			head = newNode;
			count++;
			return;
		}
		
		while (curr.next != null)
		{
			curr = curr.next;
		}
		
		curr.next = newNode;
		count++;
	}
		
	public void print()
	{		
		Node temp = head;
		while (temp != null)
		{			
			Console.Write(temp.value + "  ");
			temp = temp.next;
		}
	}		
	
	public bool searchList(int value)
	{
		Node temp = findNode(value);
		if (temp != null)
		{
			return true;
		}
		return false;
	}
	
	public bool removeHead()
	{
		if (count == 0)
		{
			return false;
		}
		head = head.next;
		count--;
		return true;
	}
	
	public bool delete(int value)
	{
		Node temp = head;
		if (count == 0)
		{
			return false;
		}
		
		if (temp.value == value)
		{
			head = head.next;
			count--;
			return true;
		}
		
		while (temp.next != null)
		{
			if (temp.next.value == value)
			{
				temp.next = temp.next.next;
				count--;
				return true;
			}
			temp = temp.next;
		}
		return false;
	}
	
	public void deleteList()
	{
		head = null;
		count = 0;
	}
	

	private Node findNode(int value)
	{
		Node temp = head;
		while (temp != null)
		{
			if (temp.value == value)
			{
				return temp;
			}
			temp = temp.next;
		}
		return null;
	}
}
// -----------------------------------------------------



// ZADATAK 3 - Hot Potato Game
// -----------------------------------------------------

// -----------------------------------------------------
public int PlayHotPotato(int totalPlayers, int initialPasses)
{
	return 0;
}
// -----------------------------------------------------

// -----------------------------------------------------
public class Queue
{
	private Node tail = null;
	private int count = 0;
	
	private class Node
	{
		internal int value;
		internal Node next;
		
		public Node(int v, Node n)
		{
			value = v;
			next = n;
		}
	}
	
	public int size()
	{
		return count;
	}
	
	public bool isEmpty
	{
		get
		{
			return count == 0;
		}
	}
	
	public void enqueue(int value)
	{
		Node temp = new Node(value, null);
		if (tail == null)
		{
			tail = temp;
			tail.next = tail;
		}
		else
		{
			temp.next = tail.next;
			tail.next = temp;
			tail = temp;
		}
		count++;
	}
	
	public int? dequeue()
	{
		if (count == 0)
		{
			return null;
		}
		
		int value = 0;
		if (tail == tail.next)
		{
			value = tail.value;
			tail = null;
		}
		else
		{
			value = tail.next.value;
			tail.next = tail.next.next;
		}
		count--;
		return value;
	}
	
	public int? peek()
	{
		if (count == 0)
		{
			return null;
		}
		
		int value;
		if (tail == tail.next)
		{
			value = tail.value;
		}
		else
		{
			value = tail.next.value;
		}
		return value;
	}
}
// -----------------------------------------------------