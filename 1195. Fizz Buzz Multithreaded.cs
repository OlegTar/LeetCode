/*You have the four functions:

printFizz that prints the word "fizz" to the console,
printBuzz that prints the word "buzz" to the console,
printFizzBuzz that prints the word "fizzbuzz" to the console, and
printNumber that prints a given integer to the console.
You are given an instance of the class FizzBuzz that has four functions: fizz, buzz, fizzbuzz and number. The same instance of FizzBuzz will be passed to four different threads:

Thread A: calls fizz() that should output the word "fizz".
Thread B: calls buzz() that should output the word "buzz".
Thread C: calls fizzbuzz() that should output the word "fizzbuzz".
Thread D: calls number() that should only output the integers.
Modify the given class to output the series [1, 2, "fizz", 4, "buzz", ...] where the ith token (1-indexed) of the series is:

"fizzbuzz" if i is divisible by 3 and 5,
"fizz" if i is divisible by 3 and not 5,
"buzz" if i is divisible by 5 and not 3, or
i if i is not divisible by 3 or 5.
Implement the FizzBuzz class:

FizzBuzz(int n) Initializes the object with the number n that represents the length of the sequence that should be printed.
void fizz(printFizz) Calls printFizz to output "fizz".
void buzz(printBuzz) Calls printBuzz to output "buzz".
void fizzbuzz(printFizzBuzz) Calls printFizzBuzz to output "fizzbuzz".
void number(printNumber) Calls printnumber to output the numbers.
 

Example 1:

Input: n = 15
Output: [1,2,"fizz",4,"buzz","fizz",7,8,"fizz","buzz",11,"fizz",13,14,"fizzbuzz"]
Example 2:

Input: n = 5
Output: [1,2,"fizz",4,"buzz"]
 

Constraints:

1 <= n <= 50*/
using System.Threading;

public class FizzBuzz {
    private int n;
    private int i;

    private SemaphoreSlim numberEvent = new SemaphoreSlim(1);
    private SemaphoreSlim fizzEvent = new SemaphoreSlim(0);
    private SemaphoreSlim buzzEvent = new SemaphoreSlim(0);
    private SemaphoreSlim fizzbuzzEvent = new SemaphoreSlim(0);

    public FizzBuzz(int n) {
        this.n = n;
        this.i = 1;
    }

    public void Pass()
    {
        if (i > n)
        {
            numberEvent.Release();        
            buzzEvent.Release();
            fizzEvent.Release();
            fizzbuzzEvent.Release();
        }

        if (i % 3 == 0 && i % 5 == 0)
        {
            fizzbuzzEvent.Release();
        }
        else if (i % 3 == 0 && i % 5 != 0)
        {
            fizzEvent.Release();
        }
        else if (i % 3 != 0 && i % 5 == 0)
        {
            buzzEvent.Release();
        }
        else 
        {
            numberEvent.Release();
        }
    }

    // printFizz() outputs "fizz".
    public void Fizz(Action printFizz) {
        while (true)
        {         
            fizzEvent.Wait();
            if (i > n) break;            
            printFizz();
            i++;
            Pass();
        }
    }

    // printBuzzz() outputs "buzz".
    public void Buzz(Action printBuzz) 
    {
        while (true)
        {         
            buzzEvent.Wait();
            if (i > n) break;            
            printBuzz();
            i++;
            Pass();
        }
    }

    // printFizzBuzz() outputs "fizzbuzz".
    public void Fizzbuzz(Action printFizzBuzz) {
        while (true)
        {         
            fizzbuzzEvent.Wait();
            if (i > n) break;            
            printFizzBuzz();
            i++;
            Pass();
        }
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Number(Action<int> printNumber) {
       while (true)
        {         
            numberEvent.Wait();
            if (i > n) break;            
            printNumber(i++);
            Pass();
        }
    }
}
