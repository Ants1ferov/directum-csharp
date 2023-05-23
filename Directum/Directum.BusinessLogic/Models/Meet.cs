namespace Directum.BusinessLogic.Models
{
    /// <summary>
    /// Модель встречи
    /// </summary>
    public class Meet
    {
        /// <summary>
        /// Идентификатор встречи
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();
        /// <summary>
        /// Название встречи
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Дата начала встречи
        /// </summary>
        public required DateTime StartDate { get; set; }
        /// <summary>
        /// Дата окончания встречи
        /// </summary>
        public required DateTime EndDate { get; set; }
        /// <summary>
        /// Время напоминания до встречи
        /// </summary>
        public required uint NotifyTime { get; set; }
        /// <summary>
        /// Описание встречи
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Признак уведомлен ли пользователь о встрече
        /// </summary>
        public bool IsNotified { get; set; }
    }
}
