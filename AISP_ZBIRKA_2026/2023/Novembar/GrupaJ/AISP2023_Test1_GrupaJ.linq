<Query Kind="Program" />

void Main()
{
	// OBAVEZNO OBEZBEDITI KOD ZA TESTIRANJE ALGORITAMA U MAIN METODI
}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1 - Dodavanje elemenata na početak cirkularne liste  
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
	public void addHead(int value)
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



// ZADATAK 2 - Razdvajanje pozitivnih i negativnih brojeva u dvostruko spregnutoj listi
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
	public void SeparatePositivesAndNegatives()
	{
		
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



// ZADATAK 3 - Perfektan broj
// -----------------------------------------------------

// -----------------------------------------------------
public static bool IsNumberPerfect(long number)
{
	return false;
}
// -----------------------------------------------------

// -----------------------------------------------------