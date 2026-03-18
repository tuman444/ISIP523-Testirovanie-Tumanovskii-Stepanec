using System;

namespace BankAccountNS
{
    /// <summary>
    /// Класс, демонстрирующий работу банковского счета.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

        private BankAccount() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса BankAccount.
        /// </summary>
        /// <param name="customerName">Имя владельца счета.</param>
        /// <param name="balance">Начальный баланс банковского счета.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Получает имя клиента — владельца счета.
        /// </summary>
        /// <value>Имя клиента в виде строки.</value>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Получает текущий баланс счета.
        /// </summary>
        /// <value>Текущая сумма на счете.</value>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Списывает указанную сумму с банковского счета.
        /// </summary>
        /// <param name="amount">Сумма, которую необходимо снять со счета.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если запрашиваемая сумма превышает текущий баланс или если сумма меньше нуля.
        /// </exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                // Передаем имя аргумента, само значение и сообщение об ошибке
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount; // Напоминаю: здесь должен быть минус, ошибку мы исправили ранее
        }

        /// <summary>
        /// Зачисляет указанную сумму на банковский счет.
        /// </summary>
        /// <param name="amount">Сумма, которую необходимо внести на счет.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если вносимая сумма меньше нуля.
        /// </exception>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                // Используем конструктор с сообщением и значением
                throw new System.ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            }
            m_balance += amount;
        }

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}