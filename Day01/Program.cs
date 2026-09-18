// 測試
int[] test1 = [];
int[] test2 = [1, 1, 2, 2, 3];
int[] test3 = [7];
if (FindMostFrequent(test1) == "陣列為空") Console.WriteLine("PASS");
else Console.WriteLine("FAIL");
if (FindMostFrequent(test2) == "1 和 2") Console.WriteLine("PASS");
else Console.WriteLine("FAIL");
if (FindMostFrequent(test3) == "7") Console.WriteLine("PASS");
else Console.WriteLine("FAIL");

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
string answer;
answer = FindMostFrequent(myArray.ToArray());
// 答案輸出
if (answer != "陣列為空")
{
    Console.WriteLine($"出現最多次的數字是： {answer}");
} else
{
    Console.WriteLine($"錯誤： {answer}");
}
Console.ReadKey();

// 篩出最多次數數字
static string FindMostFrequent(int[] numbers)
{
    if (numbers.Length == 0) return "陣列為空";

    Dictionary<int, int> dict = new Dictionary<int, int>();
    for (int i = 0; i < numbers.Length; i++)
    {
        if (dict.TryGetValue(numbers[i], out int value)) dict[numbers[i]] = value + 1;
        else dict[numbers[i]] = 1;
    }

    int[] maxNum = [numbers[0]];
    int[] dictKey = dict.Keys.ToArray();
    for (int i = 0; i < dictKey.Length; i++)
    {
        if (dict[dictKey[i]] > dict[maxNum[0]]) {
            System.Array.Resize(ref maxNum, 1);
            maxNum[0] = dictKey[i];
        } 
        else if (dict[dictKey[i]] == dict[maxNum[0]] && dictKey[i] != maxNum[0]) {
            System.Array.Resize(ref maxNum, maxNum.Length + 1);
            maxNum[maxNum.Length - 1] = dictKey[i];
        }
    }
    string answer = string.Join(" 和 ",maxNum);
    return answer;
}