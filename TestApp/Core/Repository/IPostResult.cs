using System;
using System.Collections.Generic;
using System.Text;
using TestApp.MVVM.Models;

namespace TestApp.Core.Repository
{
    public interface IPostResult
    {
        public void ConvertToJson(User user);
    }
}
