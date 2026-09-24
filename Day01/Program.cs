List<int> test1 = [1, 2, 3];
List<int> test2 = [1, 1, 1];
List<int> test3 = [0];

if (SumOfEven(test1) == 2)
{
    Console.WriteLine("PASS");
} else
{
    Console.WriteLine("FAIL");
}
if (SumOfEven(test2) == 0)
{
    Console.WriteLine("PASS");
}
else
{
    Console.WriteLine("FAIL");
}
if (SumOfEven(test3) == 0)
{
    Console.WriteLine("PASS");
}
else
{
    Console.WriteLine("FAIL");
}

static int SumOfEven(List<int> numbers)
{
    List<int> allEven = [];
    for (int i = 0; i < numbers.ToArray().Length; i++)
    {
        if (numbers[i] % 2 == 0) allEven.Add(numbers[i]);
    }
    return allEven.Sum();
}

/*using System.Linq;

// 測試
int[] test1 = [];
int[] test2 = [1, 1, 2, 2, 3];
int[] test3 = [7];
try {
    FindMostFrequent(test1);
    Console.WriteLine("FAIL");
}
catch {
    Console.WriteLine("PASS");
}

try
{
    int[] ans = FindMostFrequent(test2).ToArray();
    Array.Sort(ans);
    if (ans.SequenceEqual(new[] {1,2})) Console.WriteLine("PASS");
    else Console.WriteLine("FAIL");
}
catch
{
    Console.WriteLine("FAIL");
}

try
{
    int[] ans = FindMostFrequent(test3).ToArray();
    Array.Sort(ans);
    if (ans.SequenceEqual(new[] {7})) Console.WriteLine("PASS");
    else Console.WriteLine("FAIL");
}
catch
{
    Console.WriteLine("FAIL");
}

// 自由輸入陣列
List<int> myArray = new List<int>();
do
{
    Console.WriteLine("請輸入整數，若要停止請輸入N：");
    string? input = Console.ReadLine();
    if (string.IsNullOrEmpty(input)) Console.WriteLine("輸入不可為空");
    else if (input.ToUpper() == "N") break;
    else if (int.TryParse(input, out int result)) myArray.Add(result);
    else Console.WriteLine("僅可輸入整數");
}
while (true);

// 跑 func
try
{
    int[] answer;
    answer = FindMostFrequent(myArray.ToArray()).ToArray();
    Array.Sort(answer);
    Console.WriteLine($"出現最多次的數字是： {string.Join(" 和 ", answer)}");
} catch (Exception error)
{
    Console.WriteLine($"錯誤： {error}");
}


// 篩出最多次數數字
static List<int> FindMostFrequent(int[] numbers)
{
    if (numbers.Length == 0) throw new ArgumentException("陣列不可為空");

    Dictionary<int, int> dict = new Dictionary<int, int>();
    for (int i = 0; i < numbers.Length; i++)
    {
        if (dict.TryGetValue(numbers[i], out int value)) dict[numbers[i]] = value + 1;
        else dict[numbers[i]] = 1;
    }

    int[] dictKey = dict.Keys.ToArray();
    List<int> maxNum = [dictKey[0]];
    for (int i = 0; i < dictKey.Length; i++)
    {
        if (dict[dictKey[i]] > dict[maxNum[0]]) {
            maxNum.Clear();
            maxNum.Add(dictKey[i]);
        } 
        else if (dict[dictKey[i]] == dict[maxNum[0]] && dictKey[i] != maxNum[0]) {
            maxNum.Add(dictKey[i]);
        }
    }
    return maxNum;
}
*/