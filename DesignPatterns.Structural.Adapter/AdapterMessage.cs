using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Adapter
{
    public class AdapterMessage : LegacyMessage
    {
        private NewMessage _adaptee = new NewMessage();

        public override void Show()
        {
            _adaptee.Show();
        }
    }    
}
