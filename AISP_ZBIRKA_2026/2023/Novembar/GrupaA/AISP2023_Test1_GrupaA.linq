<Query Kind="Program" />

void Main()
{
	// OBAVEZNO OBEZBEDITI KOD ZA TESTIRANJE ALGORITAMA U MAIN METODI
}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1 - Insertion Sort
// -----------------------------------------------------
public static void Sort(long[] arr)
{

}
// -----------------------------------------------------



// ZADATAK 2 - Da li je neki broj palindrom?
// -----------------------------------------------------
public class DoublyLinkedList
{
	// ADT = struktura
	private class Node
	{
		internal int value;
		internal Node next;
		internal Node prev;
		
		public Node(int v, Node nxt, Node prv)
		{
			value = v;
			next = nxt;
			prev = prv;
		}
		
		public Node(int v)
		{
			value = v;
			next = null;
			prev = null;
		}
	}
	
	
	private Node head;
	private Node tail;
	private int count = 0;
	
	// -----------------------------------------------------
	public bool IsDoublyLinkedListPalindrome()
	{
		return false;
	}
	// -----------------------------------------------------
	
	// ADT - operacije
	public void addHead(int value)
	{
		Node newNode = new Node(value, null, null);
		
		if (count == 0)
		{
			tail = head = newNode;
		}
		else
		{
			head.prev = newNode; //head becomes the second element and has a prev. reference to the new node
			newNode.next = head;
			head = newNode;
		}
		count++;
	}	
	
	public void removeHead()
	{
		if (count == 0)
		{
			return;
		}
		
		head = head.next;
		
		if (head == null)
		{
			tail = null;
		}
		else
		{
			head.prev = null;
		}
		count--;
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
	
	public bool searchList(int value)
	{
		Node temp = findNode(value);
		if (temp != null)
		{
			return true;
		}
		return false;
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
	
	public bool delete(int value)
	{
		Node temp = findNode(value);
		
		if (temp == null)
		{
			return false;
		}
		
		if (temp.value == head.value) //if head is the element with the value to be deleted
		{
			head = head.next;
			count--;
			
			if (head != null)
			{
				head.prev = null;
			}
			else //single element in list case
			{
				tail = null;
			}
			return true;
		}
		
		if (temp.next == null) //last element case
		{
			temp.prev.next = null;
		}
		else
		{
			temp.prev.next = temp.next;
			temp.next.prev = temp.prev;
		}
		count--;
		return true;
	}
	
	public void deleteList()
	{
		head = null;
		tail = null;
		count = 0;
	}
}
// -----------------------------------------------------



// ZADATAK 3 - Brisanje uzastopnih parova iz niza brojeva
// -----------------------------------------------------

// -----------------------------------------------------
public static void ShortenArray(int[] array)
{

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