<Query Kind="Program" />

void Main()
{
	int[,] testMatrix = new int[,]
	{
		{ 2, 0, 4, 0 },
		{ 3, 5, 7, 9 },
		{ 0, 1, 1, 2 },
		{ 1, 2, 3, 4 }
	};
}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1 – Dodavanje elemenata u red (Queue Enqueue)  
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
	
	// -------------------------------------------------
	public void enqueue(int value)
	{
	
	}
	// -------------------------------------------------
	
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
			value = (int)tail.value;
		}
		else
		{
			value = tail.next.value;
		}
		return value;
	}
}
// -------------------------------------------------


// ZADATAK 2 - Paran broj neparnih vrednosti u kolonama matrice
// -------------------------------------------------
public static int[] checkEvenOddColumns(int[,] matrix, int rows, int cols)
{
	return null;
}
// -------------------------------------------------



// ZADATAK 3 - Pronalaženje maksimalno udaljenih duplikata 
// -------------------------------------------------
// -------------------------------------------------
public static int findMaximumDuplicateDistance(LinkedList list)     
{
	return -1;
}
// -------------------------------------------------

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
