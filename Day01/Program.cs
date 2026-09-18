int[] myArray = [1, 3, 3, 2, 3, 1];
Dictionary<int,int> dict = new Dictionary<int,int>();

for(int i = 0; i < myArray.Length; i++)
{
    if (dict.TryGetValue(myArray[i], out int value)) dict[myArray[i]] = value + 1;
    else dict[myArray[i]] = 1;
};

int maxNum = myArray[0];
int[] dictKey = dict.Keys.ToArray();
for(int i = 1; i < dictKey.Length; i++)
{
    if (dict[dictKey[i]] > dict[maxNum]) maxNum = dictKey[i];
};

Console.WriteLine(maxNum);
Console.ReadKey();