using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR7._2.Services;
using System;

namespace Test_PR7._2
{
    /// <summary>
    /// Класс тестирования модулей шифрования и дешифрования для .NET Framework.
    /// </summary>
    [TestClass]
    public class MatrixTests
    {
        private MatrixEncryptor _encryptor;
        private MatrixDecryptor _decryptor;

        /// <summary>
        /// Инициализация объектов перед каждым тестом.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _encryptor = new MatrixEncryptor();
            _decryptor = new MatrixDecryptor();
        }

        /// <summary>
        /// Тест 1: Позитивный сценарий шифрования (TC_FUNC_1).
        /// Проверка записи по строкам и чтения по столбцам с пробелами.
        /// </summary>
        [TestMethod]
        public void Encrypt_StandardCase_PadsWithSpacesAndTransposes()
        {
            // Arrange
            string text = "HELLO";
            int rows = 2, cols = 3;

            // Act
            string result = _encryptor.Encrypt(text, rows, cols);

            // Assert
            Assert.AreEqual("HLEO L ", result, "Шифрование выполнено некорректно.");
        }

        /// <summary>
        /// Тест 2: Позитивный сценарий дешифрования (TC_FUNC_2).
        /// </summary>
        [TestMethod]
        public void Decrypt_StandardCase_RestoresOriginalTextWithPadding()
        {
            // Arrange
            string cipher = "HLEO L ";
            int rows = 2, cols = 3;

            // Act
            string result = _decryptor.Decrypt(cipher, rows, cols);

            // Assert
            Assert.AreEqual("HELLO ", result, "Текст восстановлен неверно.");
        }

        /// <summary>
        /// Тест 3: Валидация размера матрицы (TC_NEG_1).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Encrypt_MatrixTooSmall_ThrowsArgumentException()
        {
            // "HELLO" (5 симв) не поместится в 2x2 (4 ячейки)
            _encryptor.Encrypt("HELLO", 2, 2);
        }

        /// <summary>
        /// Тест 4: Обработка пустого ввода (TC_NEG_2).
        /// </summary>
        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void Encrypt_NullOrEmptyText_ThrowsArgumentException(string input)
        {
            Assert.ThrowsException<ArgumentException>(() => _encryptor.Encrypt(input, 2, 2));
        }

        /// <summary>
        /// Тест 5: Проверка некорректных размерностей (TC_NEG_3).
        /// </summary>
        [DataTestMethod]
        [DataRow(0, 5)]
        [DataRow(5, -1)]
        public void Encrypt_InvalidDimensions_ThrowsArgumentException(int rows, int cols)
        {
            Assert.ThrowsException<ArgumentException>(() => _encryptor.Encrypt("TEST", rows, cols));
        }

        /// <summary>
        /// Тест 6: Граничный случай с одной строкой (TC_BOUND_1).
        /// </summary>
        [TestMethod]
        public void Encrypt_SingleRowMatrix_ReturnsSameTextWithPadding()
        {
            // Arrange
            string text = "ABC";
            int rows = 1, cols = 5;

            // Act
            string result = _encryptor.Encrypt(text, rows, cols);

            // Assert
            Assert.AreEqual("ABC  ", result);
        }
    }
}
