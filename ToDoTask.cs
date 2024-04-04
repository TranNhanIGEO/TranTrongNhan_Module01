using System;

namespace TranTrongNhan
{
    class ToDoTask
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public ToDoTask(string _Name, int _Priority, string _Description, string _Status)
        {
            this.Name = _Name;
            this.Priority = _Priority;
            this.Description = _Description;
            this.Status = _Status;
        }
        public void PrintTask(int _index)
        {
            Console.WriteLine($"{"STT"} {"Tên việc", 20} {"Ưu tiên", 20} {"Mô tả", 20} {"Trạng thái", 20}");
            Console.WriteLine($"{_index, 5} {Name, 20} {Priority, 20} {Description, 20} {Status, 20}");
        }
    }
}