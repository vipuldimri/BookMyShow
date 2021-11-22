using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Models.Helper
{
    public class BusinessException : Exception
    {
        public List<BusinessExceptionModel> errorMessages;
        public BusinessException(List<BusinessExceptionModel> errorMessages)
        {
            this.errorMessages = errorMessages;
        }

        public BusinessException(string key, string errorMessage)
        {
            if (errorMessages == null)
            {
                errorMessages = new List<BusinessExceptionModel>();
            }
            this.errorMessages.Add(new BusinessExceptionModel(key, errorMessage));
        }
    }

    public class BusinessExceptionModel
    {
        public readonly string key;
        public readonly string message;
        public BusinessExceptionModel(string key, string message)
        {
            this.key = key;
            this.message = message;
        }
    }
}
