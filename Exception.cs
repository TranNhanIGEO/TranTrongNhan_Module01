using System;

namespace TranTrongNhan
{
    class InvalidNumberException : Exception
    {
        public InvalidNumberException() : base("XxX Lỗi: Số không hợp lệ!") {}
    }
    class InvalidPriorityException : Exception
    {
        public InvalidPriorityException() : base("XxX Lỗi: Độ ưu tiên không hợp lệ!") {}
    }
    class InvalidTaskException : Exception
    {
        public InvalidTaskException() : base("XxX Lỗi: Việc cần làm không tồn tại!") {}
    }
    class EmptyTaskException : Exception
    {
        public EmptyTaskException() : base("XxX Lỗi: Không có việc cần làm!") {}
    }
}