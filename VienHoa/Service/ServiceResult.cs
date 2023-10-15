using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VienHoa.Service
{
    public class ServiceResult
    {
        public bool Error { get; private set; }
        public string Message { get; private set; }

        private ServiceResult(bool error, string message)
        {
            Error = error;
            Message = message;
        }

        public static ServiceResult Success(string? message = "Thành công")
        {
            return new ServiceResult(false, message);
        }

        public static ServiceResult Failed(string message = "Thất bại")
        {
            return new ServiceResult(true, message);
        }
    }
}
