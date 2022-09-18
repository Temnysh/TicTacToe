class Program
{
    public static void Main(string[] args)
    {
        int[,] field = new int[3, 3];
        int currentPlayer = 1;

        while (true)
        {
            Turn(field, currentPlayer);

            if(IsWin(field, currentPlayer))
            {
                Console.WriteLine("Победил: " + GetElementString(currentPlayer));
                return;
            }

            currentPlayer = currentPlayer == 1 ? 2 : 1;
        }

    }

    public static void Turn(int[,] field, int plElement)
    {
        Console.WriteLine("Ход игрока " + GetElementString(plElement));
        Console.WriteLine("Введите координаты Х,У. Размер поля: (" + field.GetLength(0) + "," + field.GetLength(1) + ")");
        string coordinates = Console.ReadLine();
        string[] XY = coordinates.Split(',');
        int x = int.Parse(XY[0]);
        int y = int.Parse(XY[1]);
        field[x, y] = plElement;
        Console.WriteLine();

        for (int i = 0; i < 3; i++) //строка
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(GetElementString(field[j, i]));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static string GetElementString(int element)
    {
        /* if (element == 0)
        {
            return "-";
        }
        else if (element == 1)
        {
            return "X";
        }
        else
        {
            return "0";
        } */

        return element == 0 ? "-" : element == 1 ? "X" : "0";
    }

    public static bool IsWin(int[,] field, int currentPlayer)
    {
        for (int i = 0; i < 3; i++) //строка
        {
            bool allElementsIsPl = true;
            for (int j = 0; j < 3; j++)
            {
                if (field[i, j] != currentPlayer)
                {
                    allElementsIsPl = false;
                }
            }
            
            if (allElementsIsPl)
            {
                return true;
            }
        }

        for (int j = 0; j < 3; j++) //столбец
        {
            bool allElementsIsPl = true;
            for (int i = 0; i < 3; i++)
            {
                if (field[i, j] != currentPlayer)
                {
                    allElementsIsPl = false;
                }
            }

            if (allElementsIsPl)
            {
                return true;
            }
        }

        bool allElementsIsPl1 = true; //дилогналь
        for (int i = 0; i < 3; i++)
        {
            if (field[i, i] != currentPlayer)
            {
                allElementsIsPl1 = false;
            }
        }

        if (allElementsIsPl1)
        {
            return true;
        }

        bool allElementsIsPl2 = true; //вторая диагональ
        for (int i = 0; i < 3; i++)
        {
            if (field[i, 2-i] != currentPlayer)
            {
                allElementsIsPl2 = false;
            }
        }

        if (allElementsIsPl2)
        {
            return true;
        }

        return false;
    }
}