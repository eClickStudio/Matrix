using System;
using System.Collections.Generic;

namespace List_tests
{
    class Matrix<T>
    {
        private short sizeX = 0;
        private short sizeY = 0;
        private readonly short maxSizeX;
        private readonly short maxSizeY;
        private readonly T defaultValue;
        private readonly List<List<T>> matrix = new List<List<T>>();
        public Matrix(in short startSizeX, in short startSizeY, in short maxSizeX, in short maxSizeY, in T defaultValue)
        {
            this.defaultValue = defaultValue;
            this.maxSizeX = maxSizeX;
            this.maxSizeY = maxSizeY;
            SetSize(startSizeX, startSizeY);
        }

        private void AddRight()
        {
            sizeX++;
            foreach (List<T> list in matrix)
            {
                list.Add(defaultValue);
            }
        }
        private void AddLeft()
        {
            sizeX++;
            foreach (List<T> list in matrix)
            {
                list.Insert(0, defaultValue);
            }
        }

        private void AddDown()
        {
            matrix.Add(new List<T>());
            for (short j = 0; j < sizeX; j++)
            {
                matrix[sizeY].Add(defaultValue);
            }
            sizeY++;
        }

        private void AddUp()
        {
            matrix.Insert(0, new List<T>());
            for (short j = 0; j < sizeX; j++)
            {
                matrix[0].Add(defaultValue);
            }
            sizeY++;
        }

        public void AddToIndex(in short indexX, in short indexY, in T elem)
        {
            short finalIndexX = indexX;
            short finalIndexY = indexY;
            if (indexY > 0)
            {
                finalIndexY = indexY;
            }
            else if (indexY < 0)
            {
                finalIndexY = 0;
            }
            if (indexX > 0)
            {
                finalIndexX = indexX;
            }
            else if (indexX < 0)
            {
                finalIndexX = 0;
            }

            short lastPosX = indexX;
            short lastPosY = indexY;
            if (indexY > sizeY - 1)
            {
                lastPosY = (short)(sizeY - 1);
            }
            else if (indexY < 0)
            {
                lastPosY = 0;
            }
            if (indexX > sizeX - 1)
            {
                lastPosX = (short)(sizeX - 1);
            }
            else if (indexX < 0)
            {
                lastPosX = 0;
            }

            while (lastPosY != indexY || lastPosX != indexX)
            {
                if (lastPosY != indexY)
                {
                    if (indexY > sizeY - 1)
                    {
                        AddDown();
                        lastPosY++;
                    }
                    else if (indexY < 0)
                    {
                        AddUp();
                        lastPosY--;
                    }
                }
                if (lastPosX != indexX)
                {
                    if (indexX > sizeX - 1)
                    {
                        lastPosX++;
                        AddRight();
                    }
                    else if (indexX < 0)
                    {
                        lastPosX--;
                        AddLeft();
                    }
                }
            }
            matrix[finalIndexY][finalIndexX] = elem;
        }

        public bool CanAddToIndex(in short indexX, in short indexY)
        {
            if (indexY > 0)
            {
                if (indexY > maxSizeY - 1)
                {
                    return false;
                }
            }
            else if (indexY < 0)
            {
                if (-indexY + sizeY > maxSizeY)
                {
                    return false;
                }
            }
            if (indexX > 0)
            {
                if (indexX > maxSizeX - 1)
                {
                    return false;
                }
            }
            else if (indexX < 0)
            {
                if (-indexX + sizeX > maxSizeX)
                {
                    return false;
                }
            }
            return true;
        }
        private void SetSize(short sizeX, short sizeY)
        {
            if (sizeX <= 0)
            {
                sizeX = 1;
            }
            if (sizeY <= 0)
            {
                sizeY = 1;
            }
            if (sizeX > maxSizeX)
            {
                sizeX = maxSizeX;
            }
            if (sizeY > maxSizeY)
            {
                sizeY = maxSizeY;
            }

            this.sizeX = sizeX;
            this.sizeY = sizeY;
            for (short y = 0; y < sizeY; y++)
            {
                matrix.Add(new List<T>());
                for (short x = 0; x < sizeX; x++)
                {
                    matrix[y].Add(defaultValue);
                }
            }
        }

        public void PrintMatrix()
        {
            foreach (List<T> list in matrix)
            {
                foreach (T elem in list)
                {
                    Console.Write(elem + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"SizeX = {matrix[0].Capacity}; SizeY = {matrix.Capacity}");
            Console.WriteLine($"Real - SizeX = {sizeX}; SizeY = {sizeY}");
        }
    }
}
