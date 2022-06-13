using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoardLibrary.Exceptions;

public class ColumnNotFoundException : System.Exception
{
    public ColumnNotFoundException() : base("Column not found.")
    {

    }
}
