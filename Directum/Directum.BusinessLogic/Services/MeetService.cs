using Directum.BusinessLogic.Interfaces;
using Directum.BusinessLogic.Models;
using Directum.BusinessLogic.Utils;

namespace Directum.BusinessLogic.Services
{
    public class MeetService : IMeetService
    { 
        private readonly List<Meet> _meets = new();

        public Guid CreateMeet(string name, DateTime startDate, DateTime endDate, uint notifyTime, string? description)
        {
            if (_meets.IsOverlap(startDate, endDate))
            {
                throw new Exception("Meet is overlap, change dates!");
            }

            var meet = new Meet
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                NotifyTime = notifyTime
            };
            if (description is not null) meet.Description = description;
            _meets.Add(meet);

            return meet.Id;
        }

        public void EditMeet(Guid id, string? name, DateTime? startDate, DateTime? endDate, uint? notifyTime, string? description)
        {
            if (startDate is not null &&
                endDate is not null &&
                _meets.SkipWhile(x => x.Id == id)
                    .IsOverlap(startDate.Value,
                        endDate.Value))
            {
                throw new Exception("Meet is overlap, change dates!");
            }

            var meetForUpdate = _meets.Find(x => x.Id == id);
            if (meetForUpdate is null) return;
            if (name is not null) meetForUpdate.Name = name;
            if (startDate is not null) meetForUpdate.StartDate = startDate.Value;
            if (endDate is not null) meetForUpdate.EndDate = endDate.Value;
            if (notifyTime is not null) meetForUpdate.NotifyTime = notifyTime.Value;
            if (description is not null) meetForUpdate.Description = description;
        }

        public Meet? GetMeet(Guid id)
        {
            return _meets.Find(x => x.Id == id);
        }

        public IEnumerable<Meet> GetMeets()
        {
            return _meets;
        }

        public IEnumerable<Meet> GetMeets(DateTime startDate, DateTime endDate)
        {
            return _meets.Where(x => x.StartDate >= startDate && x.EndDate <= endDate);
        }

        public bool DeleteMeet(Guid id)
        {
            var meetForDelete = _meets.Find(x => x.Id == id);
            if (meetForDelete == null) return false;

            _meets.Remove(meetForDelete);
            return true;
        }

        public string ExportToFile(DateTime day)
        {
            var meetsForDay = _meets.Find(x => x.StartDate >= day && x.EndDate <= day);

            //string path = "note.txt";


            /*using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(text);
            }*/

            return meetsForDay.ToString();
        }

        public void Notify(Meet meet)
        {
            throw new NotImplementedException();
        }
    }
}
