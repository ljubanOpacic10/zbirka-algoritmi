<Query Kind="Program" />

void Main()
{
	// MATRICE ZA TESTIRANJE DRUGOG ZADATKA
	long[,] matrix1 = new long[,]
	{
		{0, 3, 2},
		{2, 0, 4},
		{3, 4, 0}
	};
	
	long[,] matrix2 = new long[,]
	{
		{0, -1, 2},
		{2, 0, 4},
		{3, 4, 0}
	};
}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1 - Pronalaženje elementa u redu (Queue Peek)
// -------------------------------------------------
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
	
	// -------------------------------------------------
	public int? peek()
	{
		return null;
	}
	// -------------------------------------------------
}
// -------------------------------------------------



// ZADATAK 2 - Jednakost suma ispod i iznad glavne dijagonale kvadratne matrice
// -------------------------------------------------
// -------------------------------------------------
public static void findSumBelowAndAboveMainDiagonal(long[,] matrix, int rows, int cols)
{

}
// -------------------------------------------------

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
// -------------------------------------------------



// ZADATAK 3 - Kumulativna suma vrednosti levih suseda 
// -------------------------------------------------
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
	
	
	// -----------------------------------------
	public void calculateCumulativeSum()
	{
	
	}
	//------------------------------------------
	
	
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
// -------------------------------------------------
