using Directum.BusinessLogic.Models;

namespace Directum.BusinessLogic.Utils
{
    public static class Utils
    {
        public static bool IsOverlap(this IEnumerable<Meet> meets, DateTime startDate, DateTime endDate)
        {
            var isOverlap = false;
            foreach (var existingMeet in meets)
            {
                if (startDate >= existingMeet.StartDate && startDate <= existingMeet.EndDate ||
                   endDate >= existingMeet.StartDate && endDate <= existingMeet.EndDate) isOverlap = true;
            }

            return isOverlap;
        }

        public static DateTime ParseDate()
        {
            string input = Console.ReadLine();
            DateTime date;

            while (!DateTime.TryParse(input, out date))
            {
                Console.Write("Неверные данные!\nВведите снова: ");
                input = Console.ReadLine();
            }

            return date;
        }
    }
}
