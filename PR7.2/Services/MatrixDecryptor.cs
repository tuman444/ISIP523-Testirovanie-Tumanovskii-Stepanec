using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7._2.Services
{
    /// <summary>
    /// Класс для выполнения дешифрования матричного шифра.
    /// </summary>
    public class MatrixDecryptor
    {
        /// <summary>
        /// Расшифровывает текст методом записи в матрицу по столбцам и чтения по строкам.
        /// </summary>
        public string Decrypt(string cipherText, int rows, int cols)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentException("Шифротекст пуст.");

            if (cipherText.Length != rows * cols)
                throw new ArgumentException("Длина текста не соответствует размеру матрицы.");

            char[,] matrix = new char[rows, cols];
            int charIndex = 0;

            // Запись в матрицу по столбцам
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, j] = cipherText[charIndex++];
                }
            }

            // Чтение из матрицы по строкам
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(matrix[i, j]);
                }
            }

            return sb.ToString();
        }
    }
}
