using BoardGameHub.Domain.Exceptions;

namespace BoardGameHub.Domain.ValueObjects
{
    public struct PlayerCountRange
    {
        public PlayerCountRange(int minNumber, int maxNumber)
        {     
            if (minNumber > maxNumber)
            {
                throw new IncorrectPlayersCountException("Некорректный диапазон числа игроков. Минимальное число не может быть больше максимального.");
            }

            MinNumber = minNumber; 
            MaxNumber = maxNumber;
        }

        public int MinNumber {  get; }
        public int MaxNumber { get; }
    }
}
