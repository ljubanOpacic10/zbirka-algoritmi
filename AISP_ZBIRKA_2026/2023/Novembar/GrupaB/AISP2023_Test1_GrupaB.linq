<Query Kind="Program" />

void Main()
{
	// OBAVEZNO OBEZBEDITI KOD ZA TESTIRANJE ALGORITAMA U MAIN METODI
}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1 - Bubble Sort
// -----------------------------------------------------
public static void Sort(long[] arr)
{

}
// -----------------------------------------------------



// ZADATAK 2 - Invertovanje jednostruko povezane liste
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
	public void InvertList()
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



// ZADATAK 3 - Brisanje uzastopnih parova iz niza brojeva
// -----------------------------------------------------

// -----------------------------------------------------
public static bool ShortenArray(int[] array)
{
	return false;
}
// -----------------------------------------------------

public class Stack
{
	private Node head = null;
	public int count = 0; // Postavljeno na public zbog resavanja zadatka
	
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