using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core;

public interface IMessageService
{
    void DisplayMessage(string message);

    void CloseAppMessage();

    void MinimizeAppMessage();
}
