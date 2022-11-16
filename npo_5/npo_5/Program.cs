string[] args_arr = Environment.GetCommandLineArgs();

if (args_arr.Length == 2)
{
    new Exception("Нет строки. почему?");
}

string str = args_arr[1];
Console.WriteLine($"str: {str}");
List<char> list = new List<char>();
int max = 0;

for (int i = 0; i < str.Length; i++)
{
    if (list.Contains(str[i]))
    {
        list = new List<char>();
    }

    list.Add(str[i]);

    if (list.Count() > max)
    {
        max = list.Count();
    }
}

Console.WriteLine(max);