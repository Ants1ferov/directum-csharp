using Directum.BusinessLogic.Models;

namespace Directum.BusinessLogic.Interfaces
{
    public interface IMeetService
    {
        /// <summary>
        /// Создание встречи
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="startDate">Дата начала</param>
        /// <param name="endDate">Дата окончания</param>
        /// <param name="notifyTime">Время уведомления</param>
        /// <param name="description">Описание</param>
        /// <returns></returns>
        public Guid CreateMeet(string name, DateTime startDate, DateTime endDate, uint notifyTime, string? description);
        /// <summary>
        /// Изменение встречи
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        /// <param name="startDate">Дата начала</param>
        /// <param name="endDate">Дата окончания</param>
        /// <param name="notifyTime">Время уведомления</param>
        /// <param name="description">Описание</param>
        public void EditMeet(Guid id, string? name, DateTime? startDate, DateTime? endDate, uint? notifyTime, string? description);
        /// <summary>
        /// Получение встречи
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Экземляр встречи</returns>
        public Meet? GetMeet(Guid id);
        /// <summary>
        /// Получение списка встреч
        /// </summary>
        /// <returns>Список встреч</returns>
        public IEnumerable<Meet> GetMeets();
        /// <summary>
        /// Получение списка встреч за определенный период
        /// </summary>
        /// <param name="startDate">Дата начала</param>
        /// <param name="endDate">Дата окончания</param>
        /// <returns>Список встреч</returns>
        public IEnumerable<Meet> GetMeets(DateTime startDate, DateTime endDate);
        /// <summary>
        /// Удаление встречи
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Значение true - нахождения встречи и последующего ее удаления, значение false - если данной встречи нет</returns>
        public bool DeleteMeet(Guid id);
        /// <summary>
        /// Экспорт данных в файл
        /// </summary>
        /// <param name="day">Выбранный день</param>
        /// <returns></returns>
        public string ExportToFile(DateTime day);
        /// <summary>
        /// Настройка уведомления для встречи
        /// </summary>
        /// <param name="meet">Встреча</param>
        public void Notify(Meet meet);
    }
}