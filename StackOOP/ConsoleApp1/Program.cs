namespace Stack
{
    class Program
    {
        static void Main()
        {
            var stack = new StackProperties();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine(stack.Pop()); // 3
            Console.WriteLine(stack.Pop()); // 2
            Console.WriteLine(stack.Pop()); // 1


            //Console.WriteLine(stack.Pop()); This line is used to simulate the part that throws an exception

            


        }
    }
}