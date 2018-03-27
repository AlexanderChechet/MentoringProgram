using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Socket Input { get; set; } 
        public Socket Output { get; set; }
    }
}
