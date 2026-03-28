<Query Kind="Program" />

void Main()
{
	// OBAVEZNO OBEZBEDITI KOD ZA TESTIRANJE ALGORITAMA U MAIN METODI
}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1 - Brisanje elemenata iz steka (Stack Pop) 
// -----------------------------------------------------
public class Stack
{
	private Node head = null;
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
	
	public int? peek()
	{
		if (isEmpty)
		{
			return null;
		}
		
		return head.value;
	}
	
	public void push(int value)
	{
		head = new Node(value, head);
		count++;
	}
	
	// -----------------------------------------------------
	public int? pop()
	{
		return null;
	}
	// -----------------------------------------------------
	
	public void print()
	{
		Node temp = head;
		while (temp != null)
		{
			Console.Write(temp.value + " ");
			temp = temp.next;
		}
	}
}
// -----------------------------------------------------



// ZADATAK 2 - Eliminisanje negativnih brojeva iz niza
// -----------------------------------------------------

// -----------------------------------------------------
public static long[] EliminateNegatives (long[] arr)
{
	return null;
}
// -----------------------------------------------------

// -----------------------------------------------------



// ZADATAK 3 - Krišnamurtijev broj
// -----------------------------------------------------

// -----------------------------------------------------
public static int Factorial (int number)
{
	return 0;
}
// -----------------------------------------------------

public class CircularLinkedList
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

	private Node tail;
	private int count = 0;
	
	// -----------------------------------------------------
	public bool IsListKrishnamurthyNumber() 
	{
		return false;
	}
	// -----------------------------------------------------
	
	public void addHead(int value)
	{
		Node temp = new Node(value, null);
		
		if (count == 0)
		{
			tail = temp;
			temp.next = temp;
		}
		else
		{
			temp.next = tail.next;
			tail.next = temp;
		}
		count++;
	}
	
	public void addTail(int value)
	{
		Node temp = new Node(value, null);
		if (count == 0)
		{
			tail = temp;
			temp.next = temp;
		}
		else
		{
			temp.next = tail.next;
			tail.next = temp;
			tail = temp;
		}
		count++;
	}
	
	public bool searchList(int value)
	{
		Node temp = findNode(value);
		if (temp == null)
		{
			return false;
		}
		return true;
	}
	
	public void print()
	{		
		Node temp = tail;
		for (int i = 0; i < count; i++)
		{			
			Console.Write(temp.value + "  ");
			temp = temp.next;
		}
	}	
	
	public bool delete(int value)
	{
		if (count == 0)
		{
			return false;
		}
		
		Node prev = tail;
		Node curr = tail.next;
		Node head = tail.next;
		
		if (curr.value == value) //head and single element case
		{
			if (curr == curr.next) //single node case - it references itself
			{
				tail = null;
			}
			else //head case
			{
				tail.next = tail.next.next;
			}
			count--;
			return true;
		}
		
		prev = curr;
		curr = curr.next;
		
		while (curr != head)
		{
			if (curr.value == value)
			{
				if (curr == tail)
				{
					tail = prev;
				}
				prev.next = curr.next;
				count--;
				return true;
			}
			prev = curr;
			curr = curr.next;
		}
		return false;
	}
	
	public void deleteList()
	{
		tail = null;
		count = 0;
	}
	
	private Node findNode(int value)
	{
		Node temp = tail;
		for (int i = 0; i < count; i++)
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