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



// ZADATAK 2 - Da li elementi dvostruko spregnute liste stvaraju Armstrongov broj? 
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
	public bool IsNumberArmstrong()
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



// ZADATAK 3 - Isogram
// -----------------------------------------------------

// -----------------------------------------------------
public static void IsNumberIsogram(long number)
{

}
// -----------------------------------------------------

public class MergeSort
{
	private static void merge(long[] arr, long[] tmpArray, int lowerIndex, int middleIndex, int upperIndex)
	{
		int lowerStart = lowerIndex;
		int lowerStop = middleIndex;
		int upperStart = middleIndex + 1;
		int upperStop = upperIndex;
		int count = lowerIndex;
		
		//Prolazi kroz dva podniza i u temp niz upisuje sortirane elemente
		//Ova petlja staje cim se jedan niz isprazni, tj svi elemeni se prebace u temp niz
		while (lowerStart <= lowerStop && upperStart <= upperStop)
		{
			if (arr[lowerStart] < arr[upperStart])
			{
				tmpArray[count++] = arr[lowerStart++];
			}
			else
			{
				tmpArray[count++] = arr[upperStart++];
			}
		}
		
		//Naredne dve while petlje sluze da isprazne preostale elemente nizova
		//Ovo je uredu posto su podnizovi u ovom momentu sortirani
		while (lowerStart <= lowerStop)
		{
			tmpArray[count++] = arr[lowerStart++];
		}
		
		while (upperStart <= upperStop)
		{
			tmpArray[count++] = arr[upperStart++];
		}
		
		for (int i= lowerIndex; i<= upperIndex; i++)
		{
			arr[i] = tmpArray[i];
		}
	}
	
	//Rekurzivna metoda koja ce da izdeli niz na podnizove
	private static void mergeSrt(long[] arr, long[] tmpArray, int lowerIndex, int upperIndex)
	{
		if (lowerIndex >= upperIndex) //Uslov terminacije rekurzije
			return;
			
		int middleIndex = (lowerIndex + upperIndex) / 2; //Trazimo centralni element (njegov index)
		mergeSrt(arr, tmpArray, lowerIndex, middleIndex); //Rekurzivni poziv za levi podniz
		mergeSrt(arr, tmpArray, middleIndex+1, upperIndex); //Rekurzivni poziv za desni podniz
		merge(arr, tmpArray, lowerIndex, middleIndex, upperIndex); //Sortiranje i spajanje podnizova
	}
	
	//Inicijalna metoda koja se poziva za sortiranje. Prihvata niz koji zelimo da sortiramo.
	public static void sort(long[] arr)
	{
		int size = arr.Length;
		long[] tmpArray = new long[size]; //Kreira se pomocni niz za sortiranje
		mergeSrt(arr, tmpArray, 0, size-1); //Inicijalni poziv rekurzivnoj metodi. 
											//Prosledjujemo: niz koji sortiramo, pomocni niz, donju i gornju granicu niza (indekse).
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