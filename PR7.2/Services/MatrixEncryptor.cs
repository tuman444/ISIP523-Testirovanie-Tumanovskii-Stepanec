using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7._2.Services
{
    /// <summary>
    /// Класс для выполнения матричного шифрования (перестановочный шифр).
    /// </summary>
    public class MatrixEncryptor
    {
        /// <summary>
        /// Шифрует текст методом записи в матрицу по строкам и чтения по столбцам.
        /// </summary>
        /// <param name="text">Исходный текст.</param>
        /// <param name="rows">Количество строк матрицы.</param>
        /// <param name="cols">Количество столбцов матрицы.</param>
        /// <returns>Зашифрованная строка.</returns>
        /// <exception cref="ArgumentException">Выбрасывается при пустом тексте или некорректных размерах.</exception>
        public string Encrypt(string text, int rows, int cols)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Текст не может быть пустым.");

            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Размеры матрицы должны быть больше нуля.");

            if (text.Length > rows * cols)
                throw new ArgumentException("Матрица слишком мала для данного текста.");

            // Автодополнение пробелами
            string paddedText = text.PadRight(rows * cols, ' ');
            char[,] matrix = new char[rows, cols];

            // Запись в матрицу по строкам
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = paddedText[i * cols + j];
                }
            }

            // Чтение из матрицы по столбцам
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    sb.Append(matrix[i, j]);
                }
            }

            return sb.ToString();
        }
    }
}
