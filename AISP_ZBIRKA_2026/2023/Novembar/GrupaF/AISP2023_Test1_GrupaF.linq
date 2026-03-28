<Query Kind="Program" />

void Main()
{
	// OBAVEZNO OBEZBEDITI KOD ZA TESTIRANJE ALGORITAMA U MAIN METODI
}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1 - Dodavanje elementa na kraj cirkularne liste 
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
	public void addTail(int value)
	{

	}
	// -----------------------------------------------------
	
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



// ZADATAK 2 - Invertovanje niza korišćenjem strukture steka 
// -----------------------------------------------------

// -----------------------------------------------------
public static void InvertArrayUsingStack (long[] arr)
{

}
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
	
	public int? pop()
	{
		if (isEmpty)
		{
			return null;
		}
		
		int value = head.value;
		head = head.next;
		count--;
		return value;
	}
	
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



// ZADATAK 3 - Krišnamurtijev broj
// -----------------------------------------------------

// -----------------------------------------------------
public static int Factorial (int number)
{
	return 0;
}
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
	public void IsListKrishnamurthyNumber()
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