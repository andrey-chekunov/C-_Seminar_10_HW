// Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
// так чтобы в одной группе все числа в группе друг на друга не делились? 
// Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰.
// Например, для N = 50, M получается 6
// Группа 1: 1
// Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
// Группа 5: 7 16 24 36 40
// Группа 6: 5 32 48
// Вариант 2:
// Группа 1: 1
// Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
// Группа 5: 16 24 36 40
// Группа 6: 32 48
Console.Write("Input N: ");
int n = int.Parse(Console.ReadLine());
int[] tempArray = CreateArray(n);
void CreateRows(int[] arrayCheck)
{
  int[] arrayTemp = new int[arrayCheck.Length];
  int m = 1;
  int count = 0;
  int tempNumberFirst = 0;
  int tempNumberSecond = 0;
  int tempSwitch = 0;
  
  for (int i = 0; i < arrayCheck.Length; i++)
  {
    Array.Clear(arrayTemp);
    count = 0;
    if (arrayCheck[i] != 0)
    {
      arrayTemp[count] = arrayCheck[i];
      tempNumberSecond = arrayCheck[i];
      for (int j = i; j < arrayCheck.Length; j++)
      {
        if (arrayCheck[j] % tempNumberSecond != 0 || arrayCheck[j] / tempNumberSecond == 1)
        {
          tempSwitch = 0;
          tempNumberFirst = arrayCheck[j];
          for (int k = 0; k < count; k++)
          {
            if (tempNumberFirst % arrayTemp[k] == 0) tempSwitch++;
          }
          if (tempSwitch == 0)
          {
            arrayTemp[count] = arrayCheck[j];
            count++;
            arrayCheck[j] = 0;
          }
        }
      }
      Console.WriteLine($"Group №{m++}: {PrintArray(arrayTemp)}");
    }
  }
}
int[] CreateArray(int n)
{
  int[] temp = new int[n];
  for (int i = 0; i < temp.GetLength(0); i++)  temp[i] = i + 1;
  return temp;
}
string PrintArray(int[] array)
{
  string result = string.Empty;
  for (int i = 0; i < array.Length; i++)
  {
    if (array[i] != 0) result += $"{array[i],1} ";
  }
  return result;
}
CreateRows(tempArray);