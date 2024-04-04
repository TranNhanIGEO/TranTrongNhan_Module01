using System;
using System.Text;
using System.Collections.Generic;

namespace TranTrongNhan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            var toDoList = new List<ToDoTask>();
            bool isEnd = false;

            while (!isEnd)
            {
                Console.Clear();
                Console.WriteLine("--------------------------- MENU ---------------------------");
                Console.WriteLine("1. Thêm việc cần làm");
                Console.WriteLine("2. Xóa việc cần làm");
                Console.WriteLine("3. Cập nhật trạng thái");
                Console.WriteLine("4. Tìm kiếm việc cần làm");
                Console.WriteLine("5. Hiển thị danh sách việc cần làm");
                Console.WriteLine("6. Hiển thị danh sách việc cần làm theo độ ưu tiên giảm dần");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine();

                try
                {
                    Console.Write("Vui lòng chọn số để thao tác: ");
                    int num = int.Parse(Console.ReadLine());

                    switch (num)
                    {
                        case 1: Menu1(toDoList); break;
                        case 2: Menu2(toDoList); break;
                        case 3: Menu3(toDoList); break;
                        case 4: Menu4(toDoList); break;
                        case 5: Menu5(toDoList); break;
                        case 6: Menu6(toDoList); break;
                        default: throw new InvalidNumberException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("XxX Lỗi: Không được nhập chữ!");
                }
                catch (InvalidNumberException err)
                {
                    Console.WriteLine(err.Message);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                Console.WriteLine();
                Console.WriteLine("******************** Nhấn Y để kết thúc ********************");
                string endKey = Console.ReadLine();
                if (endKey == "Y" || endKey == "y") isEnd = true;
            }

            Console.ReadKey();
        }
        static void Menu1(List<ToDoTask> toDoList)
        {
            try
            {
                Console.Write("==> Nhập tên việc cần làm: ");
                string name = Console.ReadLine();
                Console.Write("==> Nhập mức độ ưu tiên (từ số 1 đến số 5): ");
                int priority = int.Parse(Console.ReadLine());
                if (priority < 1 || priority > 5) throw new InvalidPriorityException();

                Console.Write("==> Nhập mô tả việc cần làm: ");
                string description = Console.ReadLine();
                Console.Write("==> Nhập trạng thái công việc: ");
                string status = Console.ReadLine();
                var toDoTask = new ToDoTask(_Name: name, _Priority: priority, _Description: description, _Status: status);

                toDoList.Add(toDoTask);
            }
            catch (FormatException)
            {
                Console.WriteLine("XxX Lỗi: Nhập sai định dạng!");
            }
            catch (InvalidPriorityException err)
            {
                Console.WriteLine(err.Message);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        static void Menu2(List<ToDoTask> toDoList)
        {
            try
            {
                Console.Write("==> Nhập vị trí cần xóa: ");
                int index = int.Parse(Console.ReadLine());
                if (toDoList.Count < index || toDoList.Count == 0) throw new IndexOutOfRangeException();

                toDoList.RemoveAt(index);
            }
            catch (FormatException)
            {
                Console.WriteLine("XxX Lỗi: Không được nhập chữ!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("XxX Lỗi: Vị trí không tồn tại!");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        static void Menu3(List<ToDoTask> toDoList)
        {
            try
            {
                Console.Write("==> Nhập tên việc cần cập nhật trạng thái: ");
                string name = Console.ReadLine();

                ToDoTask task = toDoList.Find(task => task.Name == name);
                if (task == null) throw new InvalidTaskException();

                Console.Write("==> Nhập trạng thái mới: ");
                string status = Console.ReadLine();

                task.Status = status;
            }
            catch (InvalidTaskException err)
            {
                Console.WriteLine(err.Message);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        static void Menu4(List<ToDoTask> toDoList)
        {
            try
            {
                Console.Write("==> Nhập tên việc hoặc độ ưu tiên của việc cần tìm kiếm: ");
                string input = Console.ReadLine();

                var tasks = toDoList?.FindAll(task => task.Name == input) ?? toDoList?.FindAll(task => task.Priority == int.Parse(input));
                if (tasks?.Count == 0) throw new InvalidTaskException();

                for (int i = 0; i < toDoList?.Count; i++) tasks?[i].PrintTask(i);
            }
            catch (InvalidTaskException err)
            {
                Console.WriteLine(err.Message);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        static void Menu5(List<ToDoTask> toDoList)
        {
            Console.WriteLine("==> Danh sách việc cần làm:");
            if (toDoList.Count == 0) throw new EmptyTaskException();
            for (int i = 0; i < toDoList?.Count; i++) toDoList[i].PrintTask(i);
        }
        static void Menu6(List<ToDoTask> toDoList)
        {
            Console.WriteLine("==> Danh sách việc cần làm được sắp xếp độ ưu tiên giảm dần:");
            if (toDoList.Count == 0) throw new EmptyTaskException();
            for (int i = 0; i < toDoList?.Count; i++) toDoList[i].PrintTask(i);
        }
    }
}